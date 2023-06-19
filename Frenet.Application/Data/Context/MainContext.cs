using Frenet.Application.Data.Extensions;
using Frenet.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Frenet.Application.Data.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }
        public DbSet<QuoteHistory> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DefinirDeleteBehaviorRestricParaTodasAsModels();
            modelBuilder.DefinirVarchar250ComoPadraoParaTodasColunasString();
            modelBuilder.AplicarConfiguracoesDeMapeamento();
        }
    }
}