using Frenet.Application.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Frenet.Application.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void DefinirVarchar250ComoPadraoParaTodasColunasString(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetMaxLength(250);
            }
        }

        public static void DefinirDeleteBehaviorRestricParaTodasAsModels(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public static void AplicarConfiguracoesDeMapeamento(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuoteHistoryMap());
        }
    }
}