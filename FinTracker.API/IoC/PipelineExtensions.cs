using FinTracker.Application.Services;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using FinTracker.Infrastructure.Repositories;

namespace FinTracker.API.IoC;

public static class PipelineExtensions
{
    public static void AddComponents(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFinanceRepository, FinanceRepository>();
        services.AddScoped<IUserService, UserService>();
    }
}
