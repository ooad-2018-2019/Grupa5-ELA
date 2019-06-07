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
    public class OdgovorController : Controller
    {
        private readonly HealthyMeContext _context;

        public OdgovorController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: Odgovor
        public async Task<IActionResult> Index()
        {
            var healthyMeContext = _context.Odgovori.Include(o => o.Pitanje);
            return View(await healthyMeContext.ToListAsync());
        }

        // GET: Odgovor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori
                .Include(o => o.Pitanje)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (odgovor == null)
            {
                return NotFound();
            }

            return View(odgovor);
        }

        // GET: Odgovor/Create
        public IActionResult Create()
        {
            ViewData["PitanjeID"] = new SelectList(_context.Pitanja, "ID", "Naziv");
            return View();
        }

        // POST: Odgovor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,PitanjeID")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odgovor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PitanjeID"] = new SelectList(_context.Pitanja, "ID", "Naziv", odgovor.PitanjeID);
            return View(odgovor);
        }

        // GET: Odgovor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori.FindAsync(id);
            if (odgovor == null)
            {
                return NotFound();
            }
            ViewData["PitanjeID"] = new SelectList(_context.Pitanja, "ID", "Naziv", odgovor.PitanjeID);
            return View(odgovor);
        }

        // POST: Odgovor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naziv,PitanjeID")] Odgovor odgovor)
        {
            if (id != odgovor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odgovor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdgovorExists(odgovor.ID))
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
            ViewData["PitanjeID"] = new SelectList(_context.Pitanja, "ID", "Naziv", odgovor.PitanjeID);
            return View(odgovor);
        }

        // GET: Odgovor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovor = await _context.Odgovori
                .Include(o => o.Pitanje)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (odgovor == null)
            {
                return NotFound();
            }

            return View(odgovor);
        }

        // POST: Odgovor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odgovor = await _context.Odgovori.FindAsync(id);
            _context.Odgovori.Remove(odgovor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdgovorExists(int id)
        {
            return _context.Odgovori.Any(e => e.ID == id);
        }
    }
}
