using BlazorCA.Client;
using BlazorCA.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ITodoItemsClient>()
    .AddClasses().AsImplementedInterfaces()
    .WithScopedLifetime());

await builder.Build().RunAsync();
