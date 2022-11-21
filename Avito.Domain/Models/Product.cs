namespace Avito.Domain.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public DateOnly? Date { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
