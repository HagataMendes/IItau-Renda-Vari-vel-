using Itau.Investimentos.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Itau.Investimentos.Infrastructure.Context
{
    public class ItauInvestimentosDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ItauInvestimentosDbContext(DbContextOptions<ItauInvestimentosDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Itau.Investimentos.Core.Ativo>().HasKey(a => a.AtiId);
            modelBuilder.Entity<Itau.Investimentos.Core.Usuario>().HasKey(u => u.UsuId);
            modelBuilder.Entity<Itau.Investimentos.Core.Posicao>().HasKey(p => p.PosId);
            modelBuilder.Entity<Itau.Investimentos.Core.Operacao>().HasKey(o => o.OprId);
            modelBuilder.Entity<Itau.Investimentos.Core.Cotacao>().HasKey(c => c.CotId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
