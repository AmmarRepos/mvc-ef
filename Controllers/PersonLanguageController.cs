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

	// PersonLanguage/Edit/5
	public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Languages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


	// PersonLanguage/Add/5
	public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

	    var person = await _context.People
                .Include(p => p.Languages)
		.FirstOrDefaultAsync(m => m.Id == id);
		
	    var personLanguages = person.Languages;
		
	    var languages =  _context.Languages.ToList().Except(personLanguages);


            if (personLanguages == null)
            {
                return NotFound();
            }
	    ViewData["PersonId"] = id;
	    ViewData["PersonName"] = person.PersonName;
	    return View(languages);
        }

	// GET:PersonLanguage/AddLanguage/5
	public async Task<IActionResult> AddLanguage(int? id, int languageId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var language =  _context.Languages.Find(languageId);
	    var person = _context.People.Find(id);
            if (language == null)
            {
                return NotFound();
            }
	    ViewData["PersonId"] = id;
	    ViewData["PersonName"] = person.PersonName;
	    return View(language);
        }


        // POST: PersonLangauge/AddLanguage/5
	[HttpPost, ActionName("AddLanguage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLanguageConfirmed(int id, int languageId)
        {
	    var person = _context.People.Include(p => p.Languages).FirstOrDefault(p => p.Id == id);
	    var languageToAdd = _context.Languages.Find(languageId);
	    // person.Languages.Add(languageToAdd);
	    await _context.SaveChangesAsync();
	    return RedirectToAction("Edit", new { id = id });
        }


	// GET: PersonLanguage/DeleteLanguage/5
        public async Task<IActionResult> DeleteLanguage(int? languageId, int id)
        {
            if (languageId == null)
            {
                return NotFound();
            }

	    var language = _context.Languages.Single(u => u.Id == languageId);
	    var person = _context.People.Single(p => p.Id == id);

            if (language == null)
            {
                return NotFound();
            }
	    ViewData["PersonId"] = id;
	    ViewData["PersonName"] = person.PersonName;
            return View(language);
        }

        // POST: PersonLangauge/DeleteLanugae/5
        [HttpPost, ActionName("DeleteLanguage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLanguage(int id, int languageId)
        {
	    var person = _context.People.Include(p => p.Languages).FirstOrDefault(p => p.Id == id);
	    var languageToRemove = _context.Languages.Find(languageId);
	    person.Languages.Remove(languageToRemove);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = id });
        }

	
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
