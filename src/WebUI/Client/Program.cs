using BlazorCA.Client;
using BlazorCA.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new swaggerClient(sp.GetService<HttpClient>()));
builder.Services.AddScoped<ToDoItemService>();
builder.Services.AddScoped<ToDoListsService>();


await builder.Build().RunAsync();
