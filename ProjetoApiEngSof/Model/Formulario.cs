using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoApiEngSof.Model
{
    public class Formulario
    {
        [Key]
        public Guid Id { get; set; }

        
        public Guid? OngId { get; set; }
        [ForeignKey("OngId")]
        public virtual  Ong? Ong { get; set; }
        public string? Descricao { get; set; }
        public string? TipoOcorrencia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? localizacao { get; set; }
        public DateTime DataCadastro { get; set; } 
        public string status { get; set; }

        
        public Guid? PessoaFisicaId { get; set; }

        [ForeignKey("PessoaFisicaId")]
        public virtual PessoaFisica? PessoaFisica { get; set; }
        public virtual List<Foto>? Fotos { get; set; }
        public virtual List<Atualizacoes>? Atualizacoes { get; set; }
    }
}
