using BookStore.Api.Contracts;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class BookMapping
{
	public static Book ToEntity(this CreateBookDto book)
	{
		return new Book()
			{
				Name = book.Name,
				AuthorId = book.AuthorId,
				GenreId = book.GenreId,
				PublishDate = book.PublishDate
			};
	}
	
	public static Book ToEntity(this UpdateBookDto book, int id)
	{
		return new Book()
			{
				Id = id,
				Name = book.Name,
				AuthorId = book.AuthorId,
				GenreId = book.GenreId,
				PublishDate = book.PublishDate
			};
	}
	
	public static BookSummaryDto ToBookSummaryDto(this Book book)
	{
		return new BookSummaryDto(
				book.Id,
				book.Name,
				book.Author!.FullName,
				book.Genre!.Name,
				book.PublishDate
			);
	}
	
	public static BookDetailsDto ToBookDetailsDto(this Book book)
	{
		return new BookDetailsDto(
				book.Id,
				book.Name,
				book.AuthorId,
				book.GenreId,
				book.PublishDate
			);
	}
}
