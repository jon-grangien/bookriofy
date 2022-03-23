using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; } = "";

		public string? Description { get; set; }

		public Author Author { get; set; }

		[GraphQLIgnore]
		public int BookId { get; set; }
		[GraphQLIgnore]
		public int AuthorId { get; set; }
	}
}
