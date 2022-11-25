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
    public class PersonController : Controller
    {
        private readonly SqliteContext _context;

        public PersonController(SqliteContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var sqliteContext = _context.People.Include(p => p.City).ThenInclude(city => city.Country);
            return View(await sqliteContext.ToListAsync());
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityId");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,PersonName,CityId")] Person person)
        {
	    
	    Random rnd = new Random();
	    int num = rnd.Next();
	    person.PersonId = num;
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityId", person.CityId);
	    return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
	    // var person = await _context.People.Include(p => p.City);
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
	    ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityId", person.CityId);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,PersonName,CityId")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }
	    //            ModelState.Remove("City");
	    //            ModelState.Remove("Languages");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityId", person.CityId);
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Language(int? id)
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

	
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
