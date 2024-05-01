using BookStore.Api.Contracts;
using BookStore.Api.Data;
using BookStore.Api.Entities;
using BookStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Endpoints;

public static class GenresEndpoints
{
	const string GetGenreEndpointName = "GetGenre";
	public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("genres").WithParameterValidation();
		
		// GET /genres
		group.MapGet("/", async (BookStoreContext dbContext) => 
			await dbContext.Genres.Select(genre => genre.ToGenreDetailDto()).ToListAsync()
		);
		
		
		// GET /genres/1
		group.MapGet("/{id}", async (int id, BookStoreContext dbContext) => 
		{
			Genre? genre = await dbContext.Genres.FindAsync(id);
			
			return genre is null ? Results.NotFound() : Results.Ok(genre.ToGenreDetailDto());
		})
		  .WithName(GetGenreEndpointName);
		
		
		// POST /genres
		group.MapPost("/", async (CreateGenreDto newGenreInput, BookStoreContext dbContext) => 
		{
			Genre newGenre = newGenreInput.ToEntity();
			
			dbContext.Genres.Add(newGenre);
			await dbContext.SaveChangesAsync();
			
			return Results.CreatedAtRoute(GetGenreEndpointName, new { id = newGenre.Id }, newGenre.ToGenreDetailDto());
		});
		
		
		// PUT /genres/1
		group.MapPut("/{id}", async (int id, UpdateGenreDto updatedGenreInput, BookStoreContext dbContext) => 
		{
			var existingGenre = await dbContext.Genres.FindAsync(id);
			
			if (existingGenre == null) { return Results.NotFound(); }
			
			dbContext.Entry(existingGenre)
					 .CurrentValues
					 .SetValues(updatedGenreInput.ToEntity(id));
			
			await dbContext.SaveChangesAsync();
			
			return Results.NoContent();
		});
		
		
		// DELETE /genres/1
		group.MapDelete("/{id}", async (int id, BookStoreContext dbContext) => 
		{
			await dbContext.Genres
						   .Where(genre => genre.Id == id)
						   .ExecuteDeleteAsync();
			
			return Results.NoContent();
		});
		
		return group;
	}
}
