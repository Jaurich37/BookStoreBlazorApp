using BookStore.Api.Contracts;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class AuthorMapping
{
	public static Author ToEntity(this CreateAuthorDto author)
	{
		return new Author() 
		{
			FirstName = author.FirstName,
			MiddleName = author.MiddleName,
			LastName = author.LastName
		};
	}
	
	public static Author ToEntity(this UpdateAuthorDto author, int id)
	{
		return new Author() 
		{
			Id = id,
			Prefix = author.Prefix,
			FirstName = author.FirstName,
			MiddleName = author.MiddleName,
			LastName = author.LastName,
		};
	}
	
	public static AuthorDto ToAuthorDetailDto(this Author author)
	{
		return new AuthorDto(
			author.Id,
			author.Prefix ?? "",
			author.FirstName ?? "",
			author.MiddleName ?? "",
			author.LastName,
			author.FullName
		);
	}
}
