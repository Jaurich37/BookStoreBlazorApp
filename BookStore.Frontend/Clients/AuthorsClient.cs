using BookStore.Frontend.Models;

namespace BookStore.Frontend.Clients;

public class AuthorsClient(HttpClient httpClient)
{
	public async Task<Author[]> GetAuthorsAsync() 
		=> await httpClient.GetFromJsonAsync<Author[]>("authors") ?? [];
}
