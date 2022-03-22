using Models;

public class Mutation
{
	public Book RenameBook([ID] int id, string title, BookriofyDbContext dbContext)
	{
		var book = dbContext.Books.FirstOrDefault(b => b.Id == id);
		book.Title = title;
		dbContext.SaveChanges();
		return book;
	}

	public Book AddBook(string title, string? description, [ID] int authorId, BookriofyDbContext dbContext)
	{
		var author = dbContext.Authors.FirstOrDefault(a => a.Id == authorId);
		if (author == null)
		{
			throw new Exception("Author not found");
		}

		var book = new Book() { Title = title, Description = description, Author = author };
		dbContext.Books.Add(book);
		dbContext.SaveChanges();
		return book;
	}

	public Author AddAuthor(string name, string bio, BookriofyDbContext dbContext)
	{
		var author = new Author { Name = name, Bio = bio };
		dbContext.Authors.Add(author);
		dbContext.SaveChanges();
		return author;
	}
}