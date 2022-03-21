using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Bookriofy;
using Bookriofy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=bookriofystore.db"));

// builder.Services
// 	.AddBookriofyGraphqlClient()
// 	.ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5001/graphql"));

// builder.Services.AddGraphQLServer();

await builder.Build().RunAsync();
