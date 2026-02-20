using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID).HasColumnName("Cart_id");

            builder
                .Property(c => c.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasDefaultValue(0m);

            builder
                .Property(c => c.CreatedAt)
                .HasColumnName("Created_At")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .Property(c => c.UpdatedAt)
                .HasColumnName("Updated_At")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.UserID).HasColumnName("User_id");

            builder.HasIndex(c => c.UserID).IsUnique();

            builder
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
