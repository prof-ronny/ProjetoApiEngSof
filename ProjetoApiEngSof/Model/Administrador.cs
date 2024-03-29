using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class Administrador
    {
        [Key]   
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Autenticacao { get; set; }

    }
}
