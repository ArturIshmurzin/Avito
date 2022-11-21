using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avito.DataAccess.Postgres.FluentApi
{
    internal class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("users_pkey");

            builder.ToTable("users");

            builder.HasIndex(e => e.Email, "users_email_key").IsUnique();

            builder.HasIndex(e => e.PhoneNumber, "users_phone_number_key").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("phone_number");
            builder.Property(e => e.RegistrationDate).HasColumnName("registration_date");
        }
    }
}
