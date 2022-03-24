using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; } = "";

		public string? Description { get; set; }

		public string? ImageLink { get; set; }

		public string? Isbn10 { get; set; }

		public string? Isbn13 { get; set; }

		public int? PublishedYeas { get; set; }

		public Author Author { get; set; }

		[GraphQLIgnore]
		public int BookId { get; set; }
		[GraphQLIgnore]
		public int AuthorId { get; set; }
	}
}
