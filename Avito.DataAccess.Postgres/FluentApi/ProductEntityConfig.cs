using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avito.DataAccess.Postgres.FluentApi
{
    internal class ProductEntityConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("products_pkey");

            builder.ToTable("products");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            builder.Property(e => e.Price).HasColumnName("price");
            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_products");
        }
    }
}
