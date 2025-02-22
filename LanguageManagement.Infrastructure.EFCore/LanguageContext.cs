using LanguageManagement.Domain.Language.Agg;
using LanguageManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LanguageManagement.Infrastructure.EFCore
{
    public class LanguageContext:DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public LanguageContext(DbContextOptions<LanguageContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(LanguageMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}