﻿namespace Entitis;

public class AuthorBook
{
    public int AuthorBookId { get; set; }
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; } = null!;
    public Author Author { get; set; } = null!;
}