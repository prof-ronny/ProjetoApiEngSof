using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class Ong: Usuario
    {

        public string Cnpj { get; set; }

        public string Endereco { get; set; }   
        
    }
}
