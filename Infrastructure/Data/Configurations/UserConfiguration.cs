using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();

            builder.Property(u => u.UserName).HasMaxLength(50).IsRequired();
            builder.HasIndex(u => u.UserName).IsUnique();

            builder.Property(u => u.Email).HasMaxLength(255).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password).HasMaxLength(255).IsRequired();

            builder.Property(u => u.PhoneNumber).HasMaxLength(20);

            builder.Property(u => u.ProfilePicture).HasMaxLength(255);

            builder.Property(u => u.Address).HasColumnType("TEXT");

            builder.Property(u => u.DateOfBirth).HasColumnType("date");

            builder.Property(u => u.Role).HasMaxLength(20).HasDefaultValue(Role.Customer);
        }
    }
}
