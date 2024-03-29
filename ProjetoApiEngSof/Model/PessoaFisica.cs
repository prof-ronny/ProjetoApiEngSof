using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class PessoaFisica
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Autenticacao { get; set; }

        public string? Telefone { get; set; }

        
        
    }
}
