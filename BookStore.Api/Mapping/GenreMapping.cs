﻿using BookStore.Api.Contracts;
using BookStore.Api.Entities;

namespace BookStore.Api.Mapping;

public static class GenreMapping
{
	public static Genre ToEntity(this CreateGenreDto genre)
	{
		return new Genre() 
		{
			Name = genre.Name
		};
	}
	
	public static Genre ToEntity(this UpdateGenreDto genre, int id)
	{
		return new Genre() 
		{
			Id = id,
			Name = genre.Name
		};
	}
	
	public static GenreDto ToGenreDetailDto(this Genre genre)
	{
		return new GenreDto(
			genre.Id,
			genre.Name
		);
	}
	
}
