using Microsoft.EntityFrameworkCore;
using Models;

#nullable disable

public class BookriofyDbContext : DbContext
{
	public DbSet<Author> Authors { get; set; }
	public DbSet<Book> Books { get; set; }

	public BookriofyDbContext(DbContextOptions<BookriofyDbContext> options)
		: base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		var folder = Environment.SpecialFolder.LocalApplicationData;
		var path = Environment.GetFolderPath(folder);
		var dbPath = System.IO.Path.Join(path, "bookriofy.db");

		options.UseSqlite($"Data Source={dbPath}");
	}

	// protected override void OnModelCreating(ModelBuilder modelBuilder)
	// {
	// }
}