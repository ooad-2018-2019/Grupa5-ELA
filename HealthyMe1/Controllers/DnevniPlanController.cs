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
    public class DnevniPlanController : Controller
    {
        private readonly HealthyMeContext _context;

        public DnevniPlanController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: DnevniPlan
        public async Task<IActionResult> Index()
        {
            var healthyMeContext = _context.DnevniPlanovi.Include(d => d.Registrovani);
            return View(await healthyMeContext.ToListAsync());
        }

        // GET: DnevniPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnevniPlan = await _context.DnevniPlanovi
                .Include(d => d.Registrovani)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dnevniPlan == null)
            {
                return NotFound();
            }

            return View(dnevniPlan);
        }

        // GET: DnevniPlan/Create
        public IActionResult Create()
        {
            ViewData["RegistrovaniID"] = new SelectList(_context.Registrovani, "ID", "Ime");
            return View();
        }

        // POST: DnevniPlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Period,PreostaleKalorije,RegistrovaniID")] DnevniPlan dnevniPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dnevniPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegistrovaniID"] = new SelectList(_context.Registrovani, "ID", "Ime", dnevniPlan.RegistrovaniID);
            return View(dnevniPlan);
        }

        // GET: DnevniPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnevniPlan = await _context.DnevniPlanovi.FindAsync(id);
            if (dnevniPlan == null)
            {
                return NotFound();
            }
            ViewData["RegistrovaniID"] = new SelectList(_context.Registrovani, "ID", "Ime", dnevniPlan.RegistrovaniID);
            return View(dnevniPlan);
        }

        // POST: DnevniPlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Period,PreostaleKalorije,RegistrovaniID")] DnevniPlan dnevniPlan)
        {
            if (id != dnevniPlan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dnevniPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DnevniPlanExists(dnevniPlan.ID))
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
            ViewData["RegistrovaniID"] = new SelectList(_context.Registrovani, "ID", "Ime", dnevniPlan.RegistrovaniID);
            return View(dnevniPlan);
        }

        // GET: DnevniPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dnevniPlan = await _context.DnevniPlanovi
                .Include(d => d.Registrovani)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dnevniPlan == null)
            {
                return NotFound();
            }

            return View(dnevniPlan);
        }

        // POST: DnevniPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dnevniPlan = await _context.DnevniPlanovi.FindAsync(id);
            _context.DnevniPlanovi.Remove(dnevniPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DnevniPlanExists(int id)
        {
            return _context.DnevniPlanovi.Any(e => e.ID == id);
        }
    }
}
