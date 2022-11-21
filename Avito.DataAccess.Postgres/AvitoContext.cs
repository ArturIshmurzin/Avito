using Avito.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess.Postgres;

public partial class AvitoContext : DbContext
{
    public AvitoContext()
    {
    }

    public AvitoContext(DbContextOptions<AvitoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Avito;Username=postgres;Password=1q2w3e4r");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AvitoContext).Assembly);
    }
}
