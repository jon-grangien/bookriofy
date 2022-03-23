using Models;

namespace Data
{
	public class Subscription
	{
		[Subscribe]
		public Author AuthorAdded([EventMessage] Author author) => author;

		[Subscribe]
		public Author AuthorRemoved([EventMessage] Author author) => author;

		[Subscribe]
		public Book BookRemoved([EventMessage] Book book) => book;
	}
}