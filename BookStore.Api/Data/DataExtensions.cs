using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data;

public static class DataExtensions
{
	public static async Task MigrateDbAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		
		var dbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
		await dbContext.Database.MigrateAsync();
	}
}
