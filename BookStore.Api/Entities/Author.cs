namespace BookStore.Api.Entities;

public class Author
{
	public int Id { get; set; }
	public string? Prefix { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public required string LastName { get; set; }
	public string FullName => $"{(Prefix != null ? $"{Prefix} " : "")}{(FirstName != null ? $"{FirstName} " : "")}{(MiddleName != null ? $"{MiddleName} " : "")}{LastName}";
}
