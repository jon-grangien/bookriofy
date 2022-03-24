using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Bookriofy;
using Bookriofy.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
	.AddBookriofyGraphqlClient()
	.ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5001/graphql"))
	.ConfigureWebSocketClient(client => client.Uri = new Uri("ws://localhost:5001/graphql"));


// builder.Services.AddGraphQLServer();

await builder.Build().RunAsync();
