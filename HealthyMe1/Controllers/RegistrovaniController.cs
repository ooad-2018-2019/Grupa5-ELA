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
    public class RegistrovaniController : Controller
    {
        private readonly HealthyMeContext _context;

        public RegistrovaniController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: Registrovani
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrovani.ToListAsync());
        }

        // GET: Registrovani/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovani = await _context.Registrovani
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrovani == null)
            {
                return NotFound();
            }

            return View(registrovani);
        }

        // GET: Registrovani/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrovani/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Spol,Ime,DatumRodjenja,Visina,Tezina,Username,Password")] Registrovani registrovani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrovani);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrovani);
        }

        // GET: Registrovani/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovani = await _context.Registrovani.FindAsync(id);
            if (registrovani == null)
            {
                return NotFound();
            }
            return View(registrovani);
        }

        // POST: Registrovani/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Spol,Ime,DatumRodjenja,Visina,Tezina,Username,Password")] Registrovani registrovani)
        {
            if (id != registrovani.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrovani);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrovaniExists(registrovani.ID))
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
            return View(registrovani);
        }

        // GET: Registrovani/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrovani = await _context.Registrovani
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrovani == null)
            {
                return NotFound();
            }

            return View(registrovani);
        }

        // POST: Registrovani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrovani = await _context.Registrovani.FindAsync(id);
            _context.Registrovani.Remove(registrovani);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrovaniExists(int id)
        {
            return _context.Registrovani.Any(e => e.ID == id);
        }
    }
}
