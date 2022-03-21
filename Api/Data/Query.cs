using Data;
using Models;

public class Query
{
	public List<Book> GetBooks() => Seed.SeedData();

	public Book GetBookById(int id) => Seed.SeedData().FirstOrDefault(b => b.Id == id);
}
