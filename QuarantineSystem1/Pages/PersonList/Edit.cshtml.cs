using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuarantineSystem1.Model;

namespace QuarantineSystem1.Pages.PersonList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public EditModel(ApplicationDbContext db)

        {
            _db = db;
        }

        [BindProperty]
        public Person Person { get; set; }
        public  async Task OnGet(int id)
        {
            Person = await _db.Person.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var PersonFromDb = await _db.Person.FindAsync(keyValues: Person.Id);
                PersonFromDb.Name = Person.Name;
                PersonFromDb.Address = Person.Address;
                PersonFromDb.Barcode = Person.Barcode;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            
            }
            return RedirectToPage();
        }
    }
}
