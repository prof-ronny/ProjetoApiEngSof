using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class PessoaFisica : Usuario
    {


        public string Cpf { get; set; }
        public string DataNascimento { get; set; }


        public string? Telefone { get; set; }

        
        
    }
}
