using Entitis;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DataContext: DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    
    public DataContext(DbContextOptions<DataContext> options): base(options){}
}