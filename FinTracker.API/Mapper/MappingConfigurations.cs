using FinTracker.Domain.DTO;
using FinTracker.Domain.Entities;
using Mapster;
using System.Reflection;

namespace FinTracker.API.Mapper;

public static class MappingConfigurations
{
    public static void RegisterMaps(this IServiceCollection services)
    {

        TypeAdapterConfig<RegisterUserDTO, User>
            .NewConfig();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
