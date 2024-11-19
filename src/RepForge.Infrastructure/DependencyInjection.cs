using Microsoft.Extensions.DependencyInjection;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Infrastructure.Data.InMemory.Repositories;

namespace RepForge.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();

        return services;
    }

}
