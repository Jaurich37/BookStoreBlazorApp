using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Contracts;

public record class UpdateBookDto(
	[StringLength(50)] string Name, 
	int AuthorId,
	int GenreId, 
	DateOnly PublishDate
);
