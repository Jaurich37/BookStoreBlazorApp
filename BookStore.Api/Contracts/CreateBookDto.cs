using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Contracts;

public record class CreateBookDto(
	[Required][StringLength(50)] string Name, 
	[Required] int AuthorId,
	[Required] int GenreId, 
	[Required] DateOnly PublishDate
);
