using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Slide.Agg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
   public class SlideMapping:IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Heading).IsRequired().HasMaxLength(255);
            builder.Property(x => x.BtnText).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Text).HasMaxLength(350);

        }
    }
}
