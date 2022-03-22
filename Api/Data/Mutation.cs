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

	public Author AddAuthor(string name, string bio, BookriofyDbContext dbContext)
	{
		var author = new Author { Name = name, Bio = bio };
		dbContext.Authors.Add(author);
		dbContext.SaveChanges();
		return author;
	}
}