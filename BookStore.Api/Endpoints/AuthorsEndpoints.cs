using BookStore.Api.Contracts;
using BookStore.Api.Data;
using BookStore.Api.Entities;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class AuthorsEndpoints
{
	const string GetAuthorEndpointName = "GetAuthor";
	
	public static RouteGroupBuilder MapAuthorsEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("authors").WithParameterValidation();
		
		// GET /authors
		group.MapGet("/", async (BookStoreContext dbContext) => 
			await dbContext.Authors.Select(author => author.ToAuthorDetailDto()).ToListAsync()
		);
		
		
		// GET /authors/1
		group.MapGet("/{id}", async (int id, BookStoreContext dbContext) =>
		{
			Author? author = await dbContext.Authors.FindAsync(id);
			
			return author is null ? Results.NotFound() : Results.Ok(author.ToAuthorDetailDto());
		})
		  .WithName(GetAuthorEndpointName);
		
		
		// POST /authors
		group.MapPost("/", async (CreateAuthorDto newAuthorInput, BookStoreContext dbContext) => 
		{
			Author newAuthor = newAuthorInput.ToEntity();
			
			dbContext.Authors.Add(newAuthor);
			await dbContext.SaveChangesAsync();
			
			return Results.CreatedAtRoute(GetAuthorEndpointName, new { id = newAuthor.Id }, newAuthor.ToAuthorDetailDto());
		});
		
		
		// PUT /authors/1
		group.MapPut("/{id}", async (int id, UpdateAuthorDto updatedAuthorInput, BookStoreContext dbContext) => 
		{
			var existingAuthor = await dbContext.Authors.FindAsync(id);
			
			if (existingAuthor == null) { return Results.NotFound(); }
			
			dbContext.Entry(existingAuthor)
				 	 .CurrentValues
					 .SetValues(updatedAuthorInput.ToEntity(id));
					 
			return Results.NoContent();
		});
		
		
		// DELETE /authors/1
		group.MapDelete("/{id}", async (int id, BookStoreContext dbContext) => 
		{
			await dbContext.Authors
						   .Where(author => author.Id == id)
						   .ExecuteDeleteAsync();
			
			return Results.NoContent();
		});
		
		return group;
	}
	
}
