using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Contracts;

public record class UpdateAuthorDto(
	[StringLength(5)] string Prefix,
	[StringLength(20)] string FirstName,
	[StringLength(30)] string MiddleName,
	[Required] [StringLength(20)] string LastName,
	string FullName	
);
