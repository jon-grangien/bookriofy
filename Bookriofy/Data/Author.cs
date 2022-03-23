using System.ComponentModel.DataAnnotations;

namespace Bookriofy.Data
{
	public class Author
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[StringLength(4000)]
		public string Bio { get; set; }
	}

	public class ViewAuthor
	{
		public string Name { get; set; }
		public string? Bio { get; set; }
	}
}