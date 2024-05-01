namespace BookStore.Frontend.Models;

public class BookSummary
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required string Author { get; set; }
	public required string Genre { get; set; }
	public DateOnly PublishDate { get; set; }
}
