using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stytch.Net.IntegrationTests.Resources.Data;
using Stytch.Net.IntegrationTests.Resources.Utility;
using Stytch.Net.StytchService.Service;

namespace Stytch.Net.IntegrationTests.Resources;

public abstract class BaseTest
{
    protected TestUser TestUser = new();
    private IServiceProvider ServiceProvider { get; set; } = null!;
    protected IStytchService StytchService { get; private set; } = null!;
    private ApiFuncs ApiTool { get; set; } = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Setup Configuration
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddUserSecrets<BaseTest>();
        IConfiguration config = builder.Build();

        string? projectId = config.GetValue<string>("Stytch:ProjectId");
        if (string.IsNullOrEmpty(projectId)) throw new Exception("No projectId set in secrets");

        string? secret = config.GetValue<string>("Stytch:Secret");
        if (string.IsNullOrEmpty(secret)) throw new Exception("No Secret set in secrets");

        // Setup Dependency Injection
        ServiceCollection services = new();
        services.AddHttpClient();
        services.AddStytchServices(options =>
        {
            options.ProjectId = projectId;
            options.Secret = secret;
        });

        ServiceProvider = services.BuildServiceProvider();

        ApiTool = new ApiFuncs(projectId, secret, new HttpClient());
        StytchService = ServiceProvider.GetRequiredService<IStytchService>();
    }

    [OneTimeTearDown]
    public async Task OneTimeTeardown()
    {
        await ApiTool.DeleteAllIds();
    }
}