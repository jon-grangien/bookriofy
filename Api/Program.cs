var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddDbContext<BookriofyDbContext>(options => { });

builder.Services
	.AddMemoryCache()
	.AddGraphQLServer()
	.ModifyRequestOptions(opt => opt.IncludeExceptionDetails = isDevelopment)
	.RegisterDbContext<BookriofyDbContext>()
	.AddMutationConventions(applyToAllMutations: true)
	.AddMutationType<Mutation>()
	.AddQueryType<Query>()
	.UseAutomaticPersistedQueryPipeline()
	.AddInMemoryQueryStorage();

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
