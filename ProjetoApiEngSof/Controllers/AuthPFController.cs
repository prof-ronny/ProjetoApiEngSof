using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using ProjetoApiEngSof.Data;
using ProjetoApiEngSof.Model;

namespace ProjetoApiEngSof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthPFController : ControllerBase
    {
        private readonly EngSofContext _context;

        public AuthPFController(EngSofContext context)
        {
            _context = context;
        }

    

        



        // POST: api/AuthPF
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> AuthPessoaFisica([FromBody] JsonElement body)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var usuario = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(body.GetRawText(), options);

            if (usuario != null)
            {
                var email = usuario.ContainsKey("email") ? usuario["email"].ToString() : string.Empty;
                var senha = usuario.ContainsKey("senha") ? usuario["senha"].ToString() : string.Empty;


                var pessoa = await _context.PessoaFisica.FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
                var ong = await _context.Ong.FirstOrDefaultAsync(o => o.Email.ToLower() == email.ToLower());
                if (pessoa != null)
                {
                    string emailSenha = Convert.ToHexString((SHA256.HashData(UTF8Encoding.UTF8.GetBytes(email + senha))));
                    if (pessoa.Autenticacao.ToUpper() == emailSenha.ToUpper())
                    {
                        return Ok(new { Autenticado = "Ok", Perfil = "PessoaFisica", Id = pessoa.Id, Nome = pessoa.Nome, Email = pessoa.Email, Telefone = pessoa.Telefone, Cpf = pessoa.Cpf, DataNascimento = pessoa.DataNascimento });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else if (ong != null)
                {
                    string emailSenha = Convert.ToHexString((SHA256.HashData(UTF8Encoding.UTF8.GetBytes(email + senha))));
                    if (ong.Autenticacao.ToUpper() == emailSenha.ToUpper())
                    {
                        return Ok(new { Autenticado = "Ok", Perfil = "Entidade", Id = ong.Id, Nome = ong.Nome, Email = ong.Email, Endereco = ong.Endereco, Cnpj = ong.Cnpj });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
         


        }

        

    }
}
