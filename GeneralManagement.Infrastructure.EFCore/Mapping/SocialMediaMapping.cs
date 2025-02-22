using GeneralManagement.Domain.GeneralAgg;
using GeneralManagement.Domain.SocialMediaAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralManagement.Infrastructure.EFCore.Mapping
{
    public class SocialMediaMapping : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Link).IsRequired();
        }
    }
}