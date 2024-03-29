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
    public class AdministradorController : ControllerBase
    {
        private readonly EngSofContext _context;

        public AdministradorController(EngSofContext context)
        {
            _context = context;
        }

        // GET: api/Administrador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministrador()
        {
            return await _context.Administrador.ToListAsync();
        }

        // GET: api/Administrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(Guid id)
        {
            var administrador = await _context.Administrador.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // PUT: api/Administrador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(Guid id, Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administrador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            _context.Administrador.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.Id }, administrador);
        }

        // DELETE: api/Administrador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(Guid id)
        {
            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(Guid id)
        {
            return _context.Administrador.Any(e => e.Id == id);
        }
    }
}
