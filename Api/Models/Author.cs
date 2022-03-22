using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }

		[GraphQLIgnore]
		public int AuthorId { get; set; }

		public string Name { get; set; } = "";

		public string? Bio { get; set; }
	}
}
