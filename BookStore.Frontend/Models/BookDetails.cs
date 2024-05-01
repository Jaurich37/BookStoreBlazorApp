using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BookStore.Frontend.Converters;

namespace BookStore.Frontend.Models;

public class BookDetails
{
	public int Id { get; set; }
	[Required]
	[StringLength(50)]
	public required string Name { get; set; }
	[Required(ErrorMessage = "The Author field is required.")]
	[JsonConverter(typeof(StringConverter))]
	public string? AuthorId { get; set; }
	[Required(ErrorMessage = "The Genre field is required.")]
	[JsonConverter(typeof(StringConverter))]
	public string? GenreId { get; set; }
	public DateOnly PublishDate { get; set; }
}
