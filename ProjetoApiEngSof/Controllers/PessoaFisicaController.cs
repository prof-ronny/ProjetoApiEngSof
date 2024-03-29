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
    public class PessoaFisicaController : ControllerBase
    {
        private readonly EngSofContext _context;

        public PessoaFisicaController(EngSofContext context)
        {
            _context = context;
        }

        // GET: api/PessoaFisica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetPessoaFisica()
        {
            return await _context.PessoaFisica.ToListAsync();
        }

        // GET: api/PessoaFisica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaFisica>> GetPessoaFisica(Guid id)
        {
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return pessoaFisica;
        }

        // PUT: api/PessoaFisica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaFisica(Guid id, PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaFisica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaFisicaExists(id))
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

        // POST: api/PessoaFisica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PessoaFisica>> PostPessoaFisica(PessoaFisica pessoaFisica)
        {
            if(_context.PessoaFisica.Any(p => p.Cpf == pessoaFisica.Cpf))
            {
                return Conflict(new { mensagem = "CPF já cadastrado" });
            }
            if(_context.PessoaFisica.Any(p => p.Email == pessoaFisica.Email))
            {
                return Conflict(new {mensagem= "Email já cadastrado"});
            }   
            _context.PessoaFisica.Add(pessoaFisica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaFisica", new { id = pessoaFisica.Id }, pessoaFisica);
        }

        // DELETE: api/PessoaFisica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaFisica(Guid id)
        {
            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoaFisica.Remove(pessoaFisica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaFisicaExists(Guid id)
        {
            return _context.PessoaFisica.Any(e => e.Id == id);
        }
    }
}
