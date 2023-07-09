using DataAccess;
using Entitis;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DataSeed>();

//add CORS
builder.Services.AddCors(options =>
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5092", "http://localhost:3000");
    }));
//add DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeed>();
        if (service != null) service.SeedContext();
    }
}

app.MapGet("/books", async (DataContext db) =>
    await db.Books.ToListAsync());

app.MapGet("/books/{bookId}", async (int bookId,DataContext dp) =>
    await dp.Books.FindAsync(bookId) 
        is Book book 
        ? Results.Ok(book) :
        Results.NotFound());
app.MapGet("/author", async (DataContext db) =>
    await db.Authors.ToListAsync());
app.MapGet("/author/{authorId}", async (int authorId, DataContext db) =>
    await db.Authors.FindAsync(authorId)
        is Author author
        ? Results.Ok(author)
        : Results.NotFound());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();