﻿using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class RoleMapping:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(350).IsRequired();
            builder.OwnsMany<Permission>(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.ToTable("Permissions");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.Ignore(x=>x.Name);
                navigationBuilder.WithOwner(x => x.Role);
            });
        }
    }
}