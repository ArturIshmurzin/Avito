namespace Avito.Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Review> ReviewAuthors { get; } = new List<Review>();

    public virtual ICollection<Review> ReviewSalesmen { get; } = new List<Review>();
}
