using Microsoft.Extensions.Configuration;

namespace Stytch.Net.IntegrationTests.Resources;

public class ConfigFixture
{
    public ConfigFixture()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddUserSecrets<ConfigFixture>();
        builder.Build();
    }
}