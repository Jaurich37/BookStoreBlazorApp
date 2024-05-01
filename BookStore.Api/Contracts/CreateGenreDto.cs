using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Contracts;

public record class CreateGenreDto(
	[Required] [StringLength(30)] string Name
);
