using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Infractructure;
using UserCRUDApi.Infractructure.Interfaces;
using UserCRUDApi.Infractructure.Repositories;

namespace UserCRUDApi.Extentions;

public static class Extensions
{
    public static void ConfigureDbContext(this IServiceCollection serviceCollection,ConfigurationManager configuration)
    {
        serviceCollection.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configuration.GetConnectionString("ConnectionString"));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
    }
}