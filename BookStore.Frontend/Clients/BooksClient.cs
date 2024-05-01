using BookStore.Frontend.Models;

namespace BookStore.Frontend.Clients;

public class BooksClient(HttpClient httpClient)
{
	public async Task<BookSummary[]> GetBooksAsync() 
		=> await httpClient.GetFromJsonAsync<BookSummary[]>("books") ?? [];
	
	public async Task AddBookAsync(BookDetails book)
		=> await httpClient.PostAsJsonAsync("books", book);

	public async Task<BookDetails> GetBookAsync(int id)
		=> await httpClient.GetFromJsonAsync<BookDetails>($"books/{id}") 
			?? throw new Exception($"Could not find book with id: {id}");
	
	public async Task UpdateBookAsync(BookDetails updatedBook)
		=> await httpClient.PutAsJsonAsync($"books/{updatedBook.Id}", updatedBook);
	
	public async Task DeleteBookAsync(int id) 
		=> await httpClient.DeleteAsync($"books/{id}");
}
