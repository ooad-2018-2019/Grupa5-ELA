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
    public class PitanjeController : Controller
    {
        private readonly HealthyMeContext _context;

        public PitanjeController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: Pitanje
        public async Task<IActionResult> Index()
        {
            var healthyMeContext = _context.Pitanja.Include(p => p.Test);
            return View(await healthyMeContext.ToListAsync());
        }

        // GET: Pitanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja
                .Include(p => p.Test)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pitanje == null)
            {
                return NotFound();
            }

            return View(pitanje);
        }

        // GET: Pitanje/Create
        public IActionResult Create()
        {
            ViewData["TestID"] = new SelectList(_context.Testovi, "ID", "ID");
            return View();
        }

        // POST: Pitanje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,TestID")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pitanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestID"] = new SelectList(_context.Testovi, "ID", "ID", pitanje.TestID);
            return View(pitanje);
        }

        // GET: Pitanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja.FindAsync(id);
            if (pitanje == null)
            {
                return NotFound();
            }
            ViewData["TestID"] = new SelectList(_context.Testovi, "ID", "ID", pitanje.TestID);
            return View(pitanje);
        }

        // POST: Pitanje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naziv,TestID")] Pitanje pitanje)
        {
            if (id != pitanje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pitanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PitanjeExists(pitanje.ID))
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
            ViewData["TestID"] = new SelectList(_context.Testovi, "ID", "ID", pitanje.TestID);
            return View(pitanje);
        }

        // GET: Pitanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanja
                .Include(p => p.Test)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pitanje == null)
            {
                return NotFound();
            }

            return View(pitanje);
        }

        // POST: Pitanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pitanje = await _context.Pitanja.FindAsync(id);
            _context.Pitanja.Remove(pitanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PitanjeExists(int id)
        {
            return _context.Pitanja.Any(e => e.ID == id);
        }
    }
}
