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