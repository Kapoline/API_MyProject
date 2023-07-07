namespace Entitis;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<AuthorBook> AuthorBooks { get; set; } = null!;
}