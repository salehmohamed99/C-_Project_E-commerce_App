using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.UnitsInStock)
                .HasDefaultValue(0);

            builder.Property(p => p.IsActive)
                  .HasDefaultValue(true);

            builder.HasOne(p => p.category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
