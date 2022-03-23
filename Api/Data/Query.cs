using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class Query
{
	public List<Book> GetBooks(BookriofyDbContext dbContext)
	{
		return dbContext.Books
		.Include(b => b.Author)
		.ToList();
	}

	public Book GetBookById([ID] int id, BookriofyDbContext dbContext) => dbContext.Books.FirstOrDefault(b => b.Id == id);

	public List<Author> GetAuthors(BookriofyDbContext dbContext) => dbContext.Authors.ToList();
}
