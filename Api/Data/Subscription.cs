using Models;

namespace Data
{
	public class Subscription
	{
		[Subscribe]
		public Author AuthorAdded([EventMessage] Author author) => author;
	}
}