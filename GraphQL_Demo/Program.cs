using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQL_Demo;
using GraphQL_Demo.Mutation;
using GraphQL_Demo.Query;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Repos & GraphQL types
builder.Services.AddSingleton<IMenuRepository, MenuRepository>();
builder.Services.AddSingleton<MenuType>();
builder.Services.AddSingleton<MenuInputType>();

builder.Services.AddSingleton<MenuQuery>();

builder.Services.AddSingleton<MenuMutation>();
builder.Services.AddSingleton<MenuSchema>(); // concrete schema

// GraphQL server
builder.Services.AddGraphQL(b => b
    .AddSchema<MenuSchema>()      // use the concrete schema type
    .AddSystemTextJson());

var app = builder.Build();

app.MapGraphQL("/graphql");
app.UseGraphQLGraphiQL("/ui/graphiql", new GraphiQLOptions { GraphQLEndPoint = "/graphql" });
app.MapGet("/", () => Results.Redirect("/ui/graphiql"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
