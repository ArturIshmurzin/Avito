namespace Avito.Domain.Models;

public partial class Review
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public int? SalesmanId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual User? Salesman { get; set; }
}
