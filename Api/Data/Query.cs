using Data;
using Models;

public class Query
{
	public List<Book> GetBooks(BookriofyDbContext dbContext) => dbContext.Books.ToList();

	public Book GetBookById([ID] int id, BookriofyDbContext dbContext) => dbContext.Books.FirstOrDefault(b => b.Id == id);

	public List<Author> GetAuthors(BookriofyDbContext dbContext) => dbContext.Authors.ToList();
}
