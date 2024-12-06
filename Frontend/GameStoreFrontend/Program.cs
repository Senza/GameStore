using GameStoreFrontend.Client;
using GameStoreFrontend.Components;
using GameStoreFrontend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ?? 
    throw new Exception("GameStoreApiUrl not set");
builder.Services.AddHttpClient<GamesClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl)
);
builder.Services.AddHttpClient<GenreClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl)
);
//builder.Services.AddSingleton<GamesClient>();
//builder.Services.AddSingleton<GenreClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
