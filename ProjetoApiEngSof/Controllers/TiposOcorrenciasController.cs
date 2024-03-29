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
    public class TiposOcorrenciasController : ControllerBase
    {
        private readonly EngSofContext _context;

        public TiposOcorrenciasController(EngSofContext context)
        {
            _context = context;
        }

        // GET: api/TiposOcorrencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOcorrencia>>> GetTipoOcorrencia()
        {
            return await _context.TipoOcorrencia.ToListAsync();
        }

        // GET: api/TiposOcorrencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOcorrencia>> GetTipoOcorrencia(int id)
        {
            var tipoOcorrencia = await _context.TipoOcorrencia.FindAsync(id);

            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            return tipoOcorrencia;
        }

        // PUT: api/TiposOcorrencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOcorrencia(int id, TipoOcorrencia tipoOcorrencia)
        {
            if (id != tipoOcorrencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoOcorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOcorrenciaExists(id))
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

        // POST: api/TiposOcorrencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoOcorrencia>> PostTipoOcorrencia(TipoOcorrencia tipoOcorrencia)
        {
            _context.TipoOcorrencia.Add(tipoOcorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoOcorrencia", new { id = tipoOcorrencia.Id }, tipoOcorrencia);
        }

        // DELETE: api/TiposOcorrencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoOcorrencia(int id)
        {
            var tipoOcorrencia = await _context.TipoOcorrencia.FindAsync(id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            _context.TipoOcorrencia.Remove(tipoOcorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoOcorrenciaExists(int id)
        {
            return _context.TipoOcorrencia.Any(e => e.Id == id);
        }
    }
}
