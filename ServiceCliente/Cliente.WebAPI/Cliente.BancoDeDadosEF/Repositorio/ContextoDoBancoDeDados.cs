using Cliente.BancoDeDadosEF.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.BancoDeDadosEF.Repositorio
{
    public class ContextoDoBancoDeDados: DbContext
    {
        public const string Schema = "Cliente";

        public ContextoDoBancoDeDados() : base(GetOptions(ConstanteDoBancoDeDados.ConexaoLocal)) { }

        public ContextoDoBancoDeDados(string connectionString) : base(GetOptions(connectionString)) { }

        public ContextoDoBancoDeDados(DbContextOptions<ContextoDoBancoDeDados> options) : base(options) { }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

        }

        public DbSet<EntidadeCliente> Cliente { get; set; }
    }
}
