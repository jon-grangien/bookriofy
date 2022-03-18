using Models;

namespace Data
{
	public class Seed
	{
		public static List<Book> SeedData()
		{
			var authors = new List<Author>
			{
				new Author(1, "J.K. Rowling", "J.K. Rowling is a British novelist, screenwriter and film producer."),
				new Author(2, "Stephen King", "Stephen King is an American author of horror, suspense, fantasy, science fiction, and comic books.")
			};

			var books = new List<Book>
			{
				new Book(1, "Harry Potter and the Philosopher's Stone", "J.K. Rowling is a British novelist, screenwriter and film producer.", authors[0]),
				new Book(2, "The Shining", "Stephen King is an American author of horror, suspense, fantasy, science fiction, and comic books.", authors[1]),
			};

			return books;
		}
	}
}