using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[GraphQLIgnore]
		public int BookId { get; set; }

		public string Title { get; set; } = "";

		public string? Description;

		public Author Author { get; set; }
	}
}
