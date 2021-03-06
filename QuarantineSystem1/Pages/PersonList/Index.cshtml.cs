using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuarantineSystem1.Model;

namespace QuarantineSystem1.Pages.PersonList
{
    public class IndexModel : PageModel
    {
       
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Person> Persons { get; set; }
        public async Task OnGet()
        {
            Persons = await _db.Person.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Person = await _db.Person.FindAsync(id);
            if (Person==null)
            {
                return NotFound();
            }
            _db.Person.Remove(Person);  
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }

}
