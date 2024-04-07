using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public abstract class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Autenticacao { get; set; }
    }
}
