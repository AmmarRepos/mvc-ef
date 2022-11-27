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

	// PersonLanguage/AddAdd/5
	public async Task<IActionResult> IndexAdd(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Languages)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


	// GET: PersonLanguage/Add/5
        public async Task<IActionResult> Add(int? languageId, int id)
        {
            if (languageId == null)
            {
                return NotFound();
            }

	    var language = _context.Languages.Single(u => u.LanguageId == languageId);

            if (language == null)
            {
                return NotFound();
            }
	    ViewData["PersonId"] = id;
            return View(language);
        }

        // POST: PersonLangauge/Add/5
	[HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, int languageId)
        {
            return RedirectToAction("IndexAdd", new { id = id });
        }


	// PersonLanguage/IndexDelete/5
	public async Task<IActionResult> IndexDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Languages)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

	// GET: PersonLanguage/Delete/5
        public async Task<IActionResult> Delete(int? languageId, int id)
        {
            if (languageId == null)
            {
                return NotFound();
            }

	    var language = _context.Languages.Single(u => u.LanguageId == languageId);

            if (language == null)
            {
                return NotFound();
            }
	    ViewData["PersonId"] = id;
            return View(language);
        }

        // POST: PersonLangauge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int languageId)
        {
	    var lang =  _context.Languages.Include(g => g.People).Single(u => u.LanguageId == languageId);
	    var pers =  _context.People.Single(u => u.PersonId == id);
	    var del_lang = lang.People.Where(ugu => ugu.PersonId == id).FirstOrDefault();
	    // ModelBuilder modelBuilder = new ModelBuilder();
	    // var del_lang = modelBuilder
	    //	.Entity<Language>()
	    //	.HasMany(p => p.People)
	    //	.WithMany(p => p.Languages)
	    //	.UsingEntity(j => j.Languages.LanguageId == languageId && j.People.PersonId == id);
            _context.People.Remove(del_lang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = id });
        }

	
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
