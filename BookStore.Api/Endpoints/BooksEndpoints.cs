using BookStore.Api.Contracts;
using BookStore.Api.Data;
using BookStore.Api.Entities;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class BooksEndpoints
{
	const string GetBookEndpointName = "GetBook";

	public static RouteGroupBuilder MapBooksEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("books").WithParameterValidation();
		
		
		// GET /books
		group.MapGet("/", async (BookStoreContext dbContext) => 
			await dbContext.Books
					 .Include(book => book.Genre)
					 .Include(book => book.Author)
					 .Select(book => book.ToBookSummaryDto())
					 .ToListAsync()
		);


		// GET /books/1
		group.MapGet("/{id}", async (int id, BookStoreContext dbContext) => 
		{
			Book? book = await dbContext.Books.FindAsync(id);
			
			return book is null ? Results.NotFound() : Results.Ok(book.ToBookDetailsDto());
		})
		  .WithName(GetBookEndpointName);
		
		
		// POST /books
		group.MapPost("/", async (CreateBookDto newBookInput, BookStoreContext dbContext) => 
		{
			Book newBook = newBookInput.ToEntity();
			
			dbContext.Books.Add(newBook);
			await dbContext.SaveChangesAsync();
			
			return Results.CreatedAtRoute(GetBookEndpointName, new { id = newBook.Id }, newBook.ToBookDetailsDto());
		});


		// PUT /books/1
		group.MapPut("/{id}", async (int id, UpdateBookDto updatedBook, BookStoreContext dbContext) => 
		{
			var existingBook = await dbContext.Books.FindAsync(id);
			
			if (existingBook == null) {	return Results.NotFound(); }
			
			dbContext.Entry(existingBook)
					 .CurrentValues
					 .SetValues(updatedBook.ToEntity(id));
					 
			await dbContext.SaveChangesAsync();
			
			return Results.NoContent();
		});


		// DELETE /books
		group.MapDelete("/{id}", async (int id, BookStoreContext dbContext) => 
		{
			await dbContext.Books
						   .Where(book => book.Id == id)
						   .ExecuteDeleteAsync();
			
			return Results.NoContent();
		});
		
		return group;
	}
}
