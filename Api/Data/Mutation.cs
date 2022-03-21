using Data;
using Models;

public class Mutation
{
	public Book RenameBook(int id, string title)
	{
		var books = Seed.SeedData();
		var book = books.FirstOrDefault(b => b.Id == id);
		book = new Book(id, title, book?.Description, book?.Author);
		return book;
	}
}