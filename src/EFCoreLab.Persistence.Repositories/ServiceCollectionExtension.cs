using EFCoreLab.Persistence.Metadata.SampleDb;
using EFCoreLab.Persistence.Repositories.DataTrees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCoreLab.Persistence.Repositories;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataSource(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddEfCore(configuration);

        serviceCollection.AddTreeDataRepository();

        return serviceCollection;
    }

    private static IServiceCollection AddEfCore(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // 註冊 EF Core Db Context
        serviceCollection.AddDbContext<SampleDbContext>(
            (provider, dbContextOptionsBuilder) =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

                dbContextOptionsBuilder.UseLoggerFactory(loggerFactory)
                                       .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            },
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton);

        serviceCollection.AddDbContext<ReadOnlySampleDbContext>(
            (provider, dbContextOptionsBuilder) =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

                dbContextOptionsBuilder.UseLoggerFactory(loggerFactory)
                                       .UseSqlServer(configuration.GetConnectionString("DefaultReadOnlyConnection"))
                                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            },
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton);

        return serviceCollection;
    }

    private static IServiceCollection AddTreeDataRepository(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDataTreesRepository, DataTreesInSampleDbRepository>();
        serviceCollection.AddScoped<IDataTreesReadOnlyRepository, DataTreesInSampleDbReadOnlyRepository>();

        return serviceCollection;
    }
}
