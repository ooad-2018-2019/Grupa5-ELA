using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthyMe1.DAL;
using HealthyMe1.Models;

namespace HealthyMe1.Controllers
{
    public class PodsjetnikController : Controller
    {
        private readonly HealthyMeContext _context;

        public PodsjetnikController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: Podsjetnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Podsjetnici.ToListAsync());
        }

        // GET: Podsjetnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnici
                .FirstOrDefaultAsync(m => m.ID == id);
            if (podsjetnik == null)
            {
                return NotFound();
            }

            return View(podsjetnik);
        }

        // GET: Podsjetnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podsjetnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opis,Period,Ponavljanje")] Podsjetnik podsjetnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podsjetnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podsjetnik);
        }

        // GET: Podsjetnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnici.FindAsync(id);
            if (podsjetnik == null)
            {
                return NotFound();
            }
            return View(podsjetnik);
        }

        // POST: Podsjetnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Opis,Period,Ponavljanje")] Podsjetnik podsjetnik)
        {
            if (id != podsjetnik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podsjetnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodsjetnikExists(podsjetnik.ID))
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
            return View(podsjetnik);
        }

        // GET: Podsjetnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podsjetnik = await _context.Podsjetnici
                .FirstOrDefaultAsync(m => m.ID == id);
            if (podsjetnik == null)
            {
                return NotFound();
            }

            return View(podsjetnik);
        }

        // POST: Podsjetnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podsjetnik = await _context.Podsjetnici.FindAsync(id);
            _context.Podsjetnici.Remove(podsjetnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodsjetnikExists(int id)
        {
            return _context.Podsjetnici.Any(e => e.ID == id);
        }
    }
}
