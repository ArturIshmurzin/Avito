using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avito.DataAccess.Postgres.FluentApi
{
    internal class ReviewEntityConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.Id).HasName("reviews_pkey");

            builder.ToTable("reviews");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.AuthorId).HasColumnName("author_id");
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.SalesmanId).HasColumnName("salesman_id");

            builder.HasOne(d => d.Author).WithMany(p => p.ReviewAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reviews_author_id_fkey");

            builder.HasOne(d => d.Salesman).WithMany(p => p.ReviewSalesmen)
                    .HasForeignKey(d => d.SalesmanId)
                    .HasConstraintName("reviews_salesman_id_fkey");
        }
    }
}
