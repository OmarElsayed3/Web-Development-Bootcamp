using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.Dependencies;

public static class RepositoryDependency
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        // services.AddScoped<IUserCodeRepository, UserCodeRepository>();


        return services;
    }
}
