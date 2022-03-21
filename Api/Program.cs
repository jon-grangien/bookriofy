var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddGraphQLServer()
	.AddMutationType<Mutation>()
	.AddQueryType<Query>();

builder.Services.AddCors(option =>
{
	option.AddPolicy("allowedOrigin",
		builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
	);
});

var app = builder.Build();

app.UseCors("allowedOrigin");
app.MapGraphQL();

app.Run();
