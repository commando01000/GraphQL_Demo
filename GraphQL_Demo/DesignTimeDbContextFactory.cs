using global::GraphQL_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GraphQL_Demo
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GraphQLDbContext>
    {
        public GraphQLDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Required for dotnet ef commands
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GraphQLDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new GraphQLDbContext(optionsBuilder.Options);
        }
    }
}
