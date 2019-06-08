using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthyMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class RegistrovaniController : Controller
    {
        private readonly HealthyMeContext _context;

        public RegistrovaniController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: api/Registrovani
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registrovani>>> GetRegistrovani()
        {
            return await _context.Registrovani.ToListAsync();
        }

        // GET: api/Registrovani/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registrovani>> GetRegistrovani(int id)
        {
            var registrovani = await _context.Registrovani.FindAsync(id);
            if (registrovani == null)
            {
                return NotFound();
            }
            return registrovani;
        }
        // PUT: api/Registrovani/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrovani(int id, Registrovani registrovani)
        {
            if (id != registrovani.Id)
            {
                return BadRequest();
            }
            _context.Entry(registrovani).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrovaniExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // POST: api/Registrovani
        [HttpPost]
        public async Task<ActionResult<Registrovani>> PostRegistrovani(Registrovani registrovani)
        {
            _context.Registrovani.Add(registrovani);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRegistrovani", new { id = registrovani.Id }, registrovani);
        }
        // DELETE: api/Registrovani/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registrovani>> DeleteRegistrovani(int id)
        {
            var registrovani = await _context.Registrovani.FindAsync(id);
            if (registrovani == null)
            {
                return NotFound();
            }
            _context.Registrovani.Remove(registrovani);
            await _context.SaveChangesAsync();
            return registrovani;
        }
        private bool RegistrovaniExists(int id)
        {
            return _context.Registrovani.Any(e => e.Id == id);
        }
    }
}
