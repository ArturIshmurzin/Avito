using Avito;
using Avito.DataAccess.Interfaces.Repositories;
using Avito.DataAccess.Postgres;
using Avito.DataAccess.Postgres.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

public static class Programm
{

    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        TableReader tableReader = serviceProvider.GetRequiredService<TableReader>();

        tableReader.ReadUserTable();
        tableReader.ReadProductTable();
        tableReader.ReadReviewTable();

        TableWriter tableWriter = serviceProvider.GetRequiredService<TableWriter>();

        tableWriter.WriteTable();

        Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AvitoContext>()
            .AddSingleton<IUserRepository, UserRepository>().
            AddSingleton<IProductRepository, ProductRepository>().
            AddSingleton<IReviewRepository, ReviewRepository>().
            AddSingleton<TableReader>().
            AddSingleton<TableWriter>();
    }
}