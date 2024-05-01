using BookStore.Api.Endpoints;
using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options) : DbContext(options)
{
	public DbSet<Book> Books => Set<Book>();
	public DbSet<Genre> Genres => Set<Genre>();
	public DbSet<Author> Authors => Set<Author>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Genre>().HasData(
			new { Id = 1, Name = "Fiction" },
			new { Id = 2, Name = "Non-Fiction" },
			new { Id = 3, Name = "Biography" },
			new { Id = 4, Name = "Autobiography" },
			new { Id = 5, Name = "Children's Literature" },
			new { Id = 6, Name = "Mystery" },
			new { Id = 7, Name = "Adventure Fiction" },
			new { Id = 8, Name = "Fantasy Fiction" },
			new { Id = 9, Name = "Historical Fiction" },
			new { Id = 10, Name = "Science Fiction" }
		);
		
		modelBuilder.Entity<Author>().HasData(
			new { Id = 1, FirstName = "Orson", MiddleName = "Scott", LastName = "Card" },	
			new { Id = 2, FirstName = "John", MiddleName = "Ronald Reuei", LastName = "Tolkien" },	
			new { Id = 3, FirstName = "Herman", LastName = "Melville" },	
			new { Id = 4, FirstName = "Frank", LastName = "Herbert" },
			new { Id = 5, Prefix = "Dr.", LastName = "Seuss" },
			new { Id = 6, FirstName = "J.", MiddleName = "K.", LastName = "Rowling" },
			new { Id = 7, FirstName = "Stephen", LastName = "King" },
			new { Id = 8, FirstName = "John", LastName = "Green" },
			new { Id = 9, FirstName = "R.", MiddleName = "L.", LastName = "Stine" },
			new { Id = 10, FirstName = "Jane", LastName = "Austen" }
		);
		
		modelBuilder.Entity<Book>().HasData(
			new { Id = 1, Name = "Ender's Game", AuthorId = 1, GenreId = 10, PublishDate = new DateOnly(1985, 01, 15) },
			new { Id = 2, Name = "The Hobbit", AuthorId = 2, GenreId = 8, PublishDate = new DateOnly(1937, 09, 21) },
			new { Id = 3, Name = "Moby-Dick", AuthorId = 3, GenreId = 7, PublishDate = new DateOnly(1851, 10, 18) },
			new { Id = 4, Name = "Dune", AuthorId = 4, GenreId = 10, PublishDate = new DateOnly(1965, 08, 17) }
		);
	 }
}
