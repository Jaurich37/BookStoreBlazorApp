namespace BookStore.Api.Contracts;

public record class BookDetailsDto(
	int Id, 
	string Name, 
	int AuthorId,
	int GenreId, 
	DateOnly PublishDate
);