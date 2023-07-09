namespace Entitis;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int AuthorId { get; set; }
    public int YearPublish { get; set; }
    public string Description { get; set; } = null!;
    public string ImageURL { get; set; } = null!;
    public ICollection<AuthorBook> AuthorBooks { get; set; } = null!;
}