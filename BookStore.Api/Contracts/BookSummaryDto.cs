namespace BookStore.Api.Contracts;

public record class BookSummaryDto(
	int Id, 
	string Name, 
	string Author,
	string Genre, 
	DateOnly PublishDate
);

