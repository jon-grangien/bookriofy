namespace Bookriofy.Data
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }

		public string? ImageLink { get; set; }

		public int? PublishedYear { get; set; }
		public int AuthorId { get; set; }
	}
}
