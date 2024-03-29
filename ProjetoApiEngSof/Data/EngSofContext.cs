using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoApiEngSof.Model;

namespace ProjetoApiEngSof.Data
{
    public class EngSofContext : DbContext
    {
        public EngSofContext (DbContextOptions<EngSofContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoApiEngSof.Model.PessoaFisica> PessoaFisica { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.Ong> Ong { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.Formulario> Formulario { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.Administrador> Administrador { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.TipoOcorrencia> TipoOcorrencia { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.Atualizacoes> Atualizacoes { get; set; } = default!;
        public DbSet<ProjetoApiEngSof.Model.Foto> Foto { get; set; } = default!;    
          
    }
}
