namespace BookStore.Api.Contracts;

public record class AuthorDto(
	int Id,
	string Prefix,
	string FirstName,
	string MiddleName,
	string LastName,
	string? FullName	
);