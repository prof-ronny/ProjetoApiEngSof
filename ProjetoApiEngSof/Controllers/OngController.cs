using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApiEngSof.Data;
using ProjetoApiEngSof.Model;

namespace ProjetoApiEngSof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OngController : ControllerBase
    {
        private readonly EngSofContext _context;

        public OngController(EngSofContext context)
        {
            _context = context;
        }

        // GET: api/Ong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ong>>> GetOng()
        {
            return await _context.Ong.ToListAsync();
        }

        // GET: api/Ong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ong>> GetOng(Guid id)
        {
            var ong = await _context.Ong.FindAsync(id);

            if (ong == null)
            {
                return NotFound();
            }

            return ong;
        }

        // PUT: api/Ong/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOng(Guid id, Ong ong)
        {
            if (id != ong.Id)
            {
                return BadRequest();
            }

            _context.Entry(ong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OngExists(id))
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

        // POST: api/Ong
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ong>> PostOng(Ong ong)
        {
            _context.Ong.Add(ong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOng", new { id = ong.Id }, ong);
        }

        // DELETE: api/Ong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOng(Guid id)
        {
            var ong = await _context.Ong.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }

            _context.Ong.Remove(ong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OngExists(Guid id)
        {
            return _context.Ong.Any(e => e.Id == id);
        }
    }
}
