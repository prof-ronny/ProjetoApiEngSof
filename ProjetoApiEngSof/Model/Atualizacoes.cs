using System.ComponentModel.DataAnnotations;

namespace ProjetoApiEngSof.Model
{
    public class Atualizacoes
    {
        [Key]
        public Guid Id { get; set; }
        public Formulario Formulario { get; set; }
        public Ong Ong { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}