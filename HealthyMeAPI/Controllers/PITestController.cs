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
    public class PITestController : Controller
    {
        private readonly HealthyMeContext _context;

        public PITestController(HealthyMeContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pitest>>> GetPitest()
        {
            return await _context.Pitest.ToListAsync();
        }

        // GET: api/Pitest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pitest>> GetPitest(int id)
        {
            var pitest = await _context.Pitest.FindAsync(id);
            if (pitest == null)
            {
                return NotFound();
            }
            return pitest;
        }
        // PUT: api/Pitest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPitest(int id, Pitest pitest)
        {
            if (id != pitest.PitestId)
            {
                return BadRequest();
            }
            _context.Entry(pitest).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitestExists(id))
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
        // POST: api/Pitest
        [HttpPost]
        public async Task<ActionResult<Pitest>> PostPitest(Pitest pitest)
        {
            _context.Pitest.Add(pitest);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPitest", new { id = pitest.PitestId }, pitest);
        }
        // DELETE: api/Pitest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pitest>> DeletePitest(int id)
        {
            var pitest = await _context.Pitest.FindAsync(id);
            if (pitest == null)
            {
                return NotFound();
            }
            _context.Pitest.Remove(pitest);
            await _context.SaveChangesAsync();
            return pitest;
        }
        private bool PitestExists(int id)
        {
            return _context.Pitest.Any(e => e.PitestId == id);
        }
    }
}

