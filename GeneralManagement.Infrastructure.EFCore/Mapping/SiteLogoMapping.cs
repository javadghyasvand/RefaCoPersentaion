using GeneralManagement.Domain.LogoAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class SiteLogoMapping : IEntityTypeConfiguration<SiteLogo>
    {
        public void Configure(EntityTypeBuilder<SiteLogo> builder)
        {
            builder.ToTable("SiteLogo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Link).IsRequired().HasMaxLength(1500);
            


        }
    }
}