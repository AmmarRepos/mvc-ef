using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_ef.Models;
using System.Text.Encodings.Web;

namespace mvc_ef.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly SqliteContext _context;

        public PersonLanguageController(SqliteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Language(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Languages)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

	
        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}
