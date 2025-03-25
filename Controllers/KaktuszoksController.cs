using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI25032101.Models;

namespace RESTAPI25032101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaktuszoksController : ControllerBase
    {
        private readonly KaktuszokDbContext _context;

        public KaktuszoksController(KaktuszokDbContext context)
        {
            _context = context;
        }

        // GET: api/Kaktuszoks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kaktuszok>>> GetKaktuszoks()
        {
            return await _context.Kaktuszoks.ToListAsync();
        }

        // GET: api/Kaktuszoks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kaktuszok>> GetKaktuszok(int id)
        {
            var kaktuszok = await _context.Kaktuszoks.FindAsync(id);

            if (kaktuszok == null)
            {
                return NotFound();
            }

            return kaktuszok;
        }

        // PUT: api/Kaktuszoks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKaktuszok(int id, Kaktuszok kaktuszok)
        {
            if (id != kaktuszok.Id)
            {
                return BadRequest();
            }

            _context.Entry(kaktuszok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaktuszokExists(id))
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

        // POST: api/Kaktuszoks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kaktuszok>> PostKaktuszok(Kaktuszok kaktuszok)
        {
            _context.Kaktuszoks.Add(kaktuszok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKaktuszok", new { id = kaktuszok.Id }, kaktuszok);
        }

        // DELETE: api/Kaktuszoks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKaktuszok(int id)
        {
            var kaktuszok = await _context.Kaktuszoks.FindAsync(id);
            if (kaktuszok == null)
            {
                return NotFound();
            }

            _context.Kaktuszoks.Remove(kaktuszok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KaktuszokExists(int id)
        {
            return _context.Kaktuszoks.Any(e => e.Id == id);
        }
    }
}
