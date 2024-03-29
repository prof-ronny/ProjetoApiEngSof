using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApiEngSof.Data;
using ProjetoApiEngSof.Model;
using System.IO;

namespace ProjetoApiEngSof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        private readonly EngSofContext _context;

        public FormularioController(EngSofContext context)
        {
            _context = context;
        }

        // GET: api/Formulario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formulario>>> GetFormulario()
        {
            return await _context.Formulario.Include("PessoaFisica").Include("Ong").Include("Fotos").Include("Atualizacoes").ToListAsync();
        }

        // GET: api/Formulario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formulario>> GetFormulario(Guid id)
        {
            var formulario = await _context.Formulario.FindAsync(id);

            if (formulario == null)
            {
                return NotFound();
            }

            return formulario;
        }

        // GET: api/Formulario/5
        [HttpGet("PessoaFisica/{id}")]
        public async Task<ActionResult<List<Formulario>>> GetFormularioPorPessoa(Guid id)
        {
            var formulario =  _context.Formulario.Include("PessoaFisica").Include("Ong").Include("Fotos").Include("Atualizacoes").Where (p=>p.PessoaFisica.Id==id);

            if (formulario == null)
            {
                return NotFound();
            }

            return formulario.ToList();
        }

        // PUT: api/Formulario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormulario(Guid id, Formulario formulario)
        {
            if (id != formulario.Id)
            {
                return BadRequest();
            }

            _context.Entry(formulario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioExists(id))
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

        // POST: api/Formulario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Formulario>> PostFormulario(Formulario formulario)
        {
            

            _context.Formulario.Add(formulario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormulario", new { id = formulario.Id }, formulario);
        }

        // DELETE: api/Formulario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulario(Guid id)
        {
            var formulario = await _context.Formulario.Include("Fotos").Where(f=>f.Id ==id).FirstOrDefaultAsync();
            if (formulario == null)
            {
                return NotFound();
            }

            foreach(var foto in formulario.Fotos)
            {
                DeleteFile(foto.Nome);
                _context.Foto.Remove(foto);
            }

            _context.Formulario.Remove(formulario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormularioExists(Guid id)
        {
            return _context.Formulario.Any(e => e.Id == id);
        }

        private void DeleteFile(string fileName)
        {
            // Construir o caminho completo do arquivo
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            // Verificar se o arquivo existe
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    // Deletar o arquivo
                     System.IO.File.Delete(filePath);
                }
                catch (IOException ioExp)
                {
                    // Tratar possíveis erros (por exemplo, o arquivo está em uso)
                    Console.WriteLine(ioExp.Message);
                }
            }
        }
    }
}
