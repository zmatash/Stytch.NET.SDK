using Microsoft.Extensions.DependencyInjection;
using Stytch.Net.StytchService.Service;

namespace Stytch.Net;

public static class StytchServiceCollectionExtensions
{
    public static IServiceCollection AddStytchServices(this IServiceCollection services,
        Action<StytchConfiguration> configure)
    {
        services.Configure(configure);
        services.AddTransient<IStytchService, StytchService.Service.StytchService>();
        return services;
    }
}