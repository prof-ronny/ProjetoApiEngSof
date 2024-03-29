using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class Ong
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Autenticacao { get; set; }
        public string Endereco { get; set; }   
        
    }
}
