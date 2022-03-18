using Data;
using Models;

public class Query
{
	public string Hello() => "World";

	public List<Book> GetBooks() => Seed.SeedData();

	public Book GetBookById(int id) => Seed.SeedData().FirstOrDefault(b => b.Id == id);
}
