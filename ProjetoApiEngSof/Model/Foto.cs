using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class Foto
    {
        [Key]
        public Guid Id { get; set; }        
        public string Nome { get; set; }
        public string Caminho { get; set; }

        public virtual Formulario Formulario { get; set; }
        
    }
}