namespace Bookriofy.Data
{
	public class Author
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Bio { get; set; }
	}

	public class ViewAuthor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Bio { get; set; }
	}
}
