using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Contracts;

public record class UpdateGenreDto(
	[Required] [StringLength(30)] string Name
);