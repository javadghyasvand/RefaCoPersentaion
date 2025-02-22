using GeneralManagement.Domain.GeneralAgg;
using GeneralManagement.Domain.LogoAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class GeneralSettingMapping : IEntityTypeConfiguration<GeneralSetting>
    {
        public void Configure(EntityTypeBuilder<GeneralSetting> builder)
        {
            builder.ToTable("GeneralSetting");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SiteTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.SiteTitle).IsRequired().HasMaxLength(180);
            builder.Property(x => x.MetaKeywords).IsRequired().HasMaxLength(250);
            builder.Property(x => x.AdminEmail).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.PhoneNumbers).IsRequired();
        }
    }
}