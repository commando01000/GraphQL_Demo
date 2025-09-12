using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQL_Demo;
using GraphQL_Demo.Data;
using GraphQL_Demo.Mutation;
using GraphQL_Demo.Query;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();


        // Add EF Core
        builder.Services.AddDbContext<GraphQLDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Repos & GraphQL types
        builder.Services.AddScoped<IMenuRepository, MenuRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

        builder.Services.AddScoped<MenuQuery>();
        builder.Services.AddScoped<RootQuery>();

        builder.Services.AddScoped<MenuMutation>();
        builder.Services.AddScoped<ISchema>(provider =>
        {
            return new RootSchema(provider)
            {
                Query = provider.GetRequiredService<RootQuery>(),
                Mutation = provider.GetRequiredService<MenuMutation>()
            };
        });


        // GraphQL server
        builder.Services
            .AddGraphQL(b => b
                .AddSchema<RootSchema>()
                .AddSystemTextJson() // or .AddNewtonsoftJson()
                .AddGraphTypes(typeof(RootSchema).Assembly) // For auto-registering types
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true) // Optional, for debugging
            );

        var app = builder.Build();

        app.MapGraphQL("/graphql");
        app.UseGraphQLGraphiQL("/ui/graphiql", new GraphiQLOptions { GraphQLEndPoint = "/graphql" });
        app.MapGet("/", () => Results.Redirect("/ui/graphiql"));

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}