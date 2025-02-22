using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class OrderMapping :IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IssueTrackingNo).HasMaxLength(20);
            builder.OwnsMany(x => x.OrderItems, navigationBuilder =>
            {
                navigationBuilder.ToTable("OrderItem");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
            });

        }
    }
}