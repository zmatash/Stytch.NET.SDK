using Microsoft.Extensions.DependencyInjection;
using Stytch.Net.Services.MagicLinks;
using Stytch.Net.Services.Users;

namespace Stytch.Net;

public static class StytchServiceCollectionExtensions
{
    public static IServiceCollection AddStytchServices(this IServiceCollection services,
        Action<StytchConfiguration> configure)
    {
        services.Configure(configure);
        services.AddTransient<IStytchUserService, StytchUserService>();
        services.AddTransient<IStytchMagicLinkService, StytchMagicLinkService>();
        return services;
    }
}