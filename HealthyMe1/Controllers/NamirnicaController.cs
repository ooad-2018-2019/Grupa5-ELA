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
    public class NamirnicaController : Controller
    {
        private readonly HealthyMeContext _context;

        public NamirnicaController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: Namirnica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Namirnice.ToListAsync());
        }

        // GET: Namirnica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namirnica = await _context.Namirnice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (namirnica == null)
            {
                return NotFound();
            }

            return View(namirnica);
        }

        // GET: Namirnica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Namirnica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,Kalorije,Proteini,Ugljikohidrati,Masti")] Namirnica namirnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(namirnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(namirnica);
        }

        // GET: Namirnica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namirnica = await _context.Namirnice.FindAsync(id);
            if (namirnica == null)
            {
                return NotFound();
            }
            return View(namirnica);
        }

        // POST: Namirnica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naziv,Kalorije,Proteini,Ugljikohidrati,Masti")] Namirnica namirnica)
        {
            if (id != namirnica.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(namirnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NamirnicaExists(namirnica.ID))
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
            return View(namirnica);
        }

        // GET: Namirnica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var namirnica = await _context.Namirnice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (namirnica == null)
            {
                return NotFound();
            }

            return View(namirnica);
        }

        // POST: Namirnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var namirnica = await _context.Namirnice.FindAsync(id);
            _context.Namirnice.Remove(namirnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NamirnicaExists(int id)
        {
            return _context.Namirnice.Any(e => e.ID == id);
        }
    }
}
