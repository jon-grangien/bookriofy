using HotChocolate.Subscriptions;
using Models;
using Data;

public class Mutation
{
	public Book RenameBook([ID] int id, string title, BookriofyDbContext dbContext)
	{
		var book = dbContext.Books.FirstOrDefault(b => b.Id == id);
		book.Title = title;
		dbContext.SaveChanges();
		return book;
	}

	public Book? EditBook([ID] int id, string title, string desc, string? isbn10, int? year, string? imageLink, BookriofyDbContext dbContext)
	{
		try
		{
			var book = dbContext.Books.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				throw new Exception("Book not found");
			}

			book.Title = title;
			book.Description = desc;
			book.Isbn10 = isbn10;
			book.PublishedYear = year;
			book.ImageLink = imageLink;
			dbContext.SaveChanges();
			return book;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return null;
		}
	}

	public Book AddBook(string title, string? description, string? isbn10, int? year, string? imageLink, [ID] int authorId, BookriofyDbContext dbContext)
	{
		var author = dbContext.Authors.FirstOrDefault(a => a.Id == authorId);
		if (author == null)
		{
			throw new Exception("Author not found");
		}

		var book = new Book() { Title = title, Description = description, Isbn10 = isbn10, PublishedYear = year, ImageLink = imageLink, Author = author };
		dbContext.Books.Add(book);
		dbContext.SaveChanges();
		return book;
	}

	public async Task<Author> AddAuthor(string name, string bio, BookriofyDbContext dbContext, [Service] ITopicEventSender sender)
	{
		var author = new Author { Name = name, Bio = bio };
		dbContext.Authors.Add(author);
		await dbContext.SaveChangesAsync();

		await sender.SendAsync(nameof(Subscription.AuthorAdded), author);

		return author;
	}

	public async Task<Author> RemoveAuthor([ID] int id, BookriofyDbContext dbContext, [Service] ITopicEventSender sender)
	{
		var author = dbContext.Authors.FirstOrDefault(a => a.Id == id);
		if (author != null)
		{
			try
			{
				var books = dbContext.Books.Where(b => b.AuthorId == id).ToArray();
				if (books != null)
				{
					dbContext.RemoveRange(books);
					foreach (var book in books)
					{
						await sender.SendAsync(nameof(Subscription.BookRemoved), book);
					}
				}

				dbContext.Authors.Remove(author);
				await sender.SendAsync(nameof(Subscription.AuthorRemoved), author);

			}
			catch (Exception ex)
			{
				throw new Exception("Could not remove author or books " + ex.Message);
			}
			finally
			{
				await dbContext.SaveChangesAsync();
			}

			return author;
		}

		return null;
	}
}