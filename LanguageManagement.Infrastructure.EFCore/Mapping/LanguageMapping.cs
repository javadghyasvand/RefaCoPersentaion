using LanguageManagement.Domain.Language.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageManagement.Infrastructure.EFCore.Mapping
{
    public class LanguageMapping:IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.LanguageTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LanguageNameAr).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LanguageNameRu).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LanguageNameEn).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LanguageNameFa).IsRequired().HasMaxLength(500);
        }
    }
}