using Entitis;

namespace DataAccess;

public class DataSeed
{
    private readonly DataContext _dataContext;

    public DataSeed(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void SeedContext()
    {
        if (!_dataContext.Authors.Any())
        {
            var authors = new List<AuthorBook>()
            {
                new AuthorBook()
                {
                    Book = new Book()
                    {
                        Name = "The Goldfinch",
                        Description =
                            "The Goldfinch centers on 13-year-old Theodore Decker, and the dramatic changes his life undergoes after he survives a terrorist attack at the Metropolitan Museum of Art that kills his mother and results in him coming into possession of Carel Fabritius's painting The Goldfinch.",
                        YearPublish = 2013,
                        ImageURL = @"https://en.wikipedia.org/wiki/The_Goldfinch_(novel)#/media/File:The_goldfinch_by_donna_tart.png"
                    },
                    Author = new Author()
                    {
                        FullName = "Donna Tartt",
                        Description =
                            "Donna Louise Tartt is an American novelist and essayist. Her work has been widely critically-acclaimed, and her novel The Goldfinch won the Pulitzer Prize for Fiction and has been adapted into a film."
                    }
                },
                new AuthorBook()
                {
                    Book = new Book()
                    {
                        Name = "The Secret History",
                        Description = "The Secret History is an inverted detective story narrated by one of the six students, Richard Papen, who reflects years later upon the situation that led to the murder of their friend Edmund Bunny Corcoran – wherein the events leading up to the murder are revealed sequentially. The novel explores the circumstances and lasting effects of Bunny's death on the academically and socially isolated group of classics students of which he was a part.",
                        YearPublish = 1992,
                        ImageURL =@"https://en.wikipedia.org/wiki/The_Secret_History#/media/File:The_Secret_History,_front_cover.jpg",
                    },
                    Author = new Author()
                    {
                        FullName = "Donna Tartt",
                        Description =
                            "Donna Louise Tartt is an American novelist and essayist. Her work has been widely critically-acclaimed, and her novel The Goldfinch won the Pulitzer Prize for Fiction and has been adapted into a film."
                    }
                }
            };
            _dataContext.AuthorBooks.AddRange(authors);
            _dataContext.SaveChanges();
        }
    }
}