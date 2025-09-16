using LibraryGraphQL.Data;
using LibraryGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add Services 
        builder.Services.AddDbContext<LibraryContext>(options =>
        options.UseSqlite("Data Source=library.db"));

        builder.Services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.MapGraphQL("/graphql");
        app.MapGet("/", () => Results.Redirect("/graphql"));

        app.Run();
    }
}
