using BookStore.Frontend.Clients;
using BookStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

var bookStoreApiUrl = builder.Configuration["BookStoreApiUrl"] ?? throw new Exception("BookStoreApiUrl is not set");

builder.Services.AddHttpClient<BooksClient>(client => client.BaseAddress = new Uri(bookStoreApiUrl));

builder.Services.AddHttpClient<AuthorsClient>(client => client.BaseAddress = new Uri(bookStoreApiUrl));

builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(bookStoreApiUrl));

// builder.Services.AddSingleton<BooksClient>();
// builder.Services.AddSingleton<AuthorsClient>();
// builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
