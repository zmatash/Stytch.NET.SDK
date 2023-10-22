using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stytch.Net.IntegrationTests.Resources.Data.Factories;
using Stytch.Net.IntegrationTests.Resources.Utility;
using Stytch.Net.Services.MagicLinks;
using Stytch.Net.Services.Users;

namespace Stytch.Net.IntegrationTests.Resources;

public abstract class BaseTest
{
    private IServiceProvider ServiceProvider { get; set; } = null!;
    protected IStytchUserService UserService { get; private set; } = null!;
    protected IStytchMagicLinkService MagicLinkService { get; private set; } = null!;
    private ApiFuncs ApiTool { get; set; } = null!;
    protected TestUserFactory UserFactory { get; set; } = null!;

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

        // Helper classes
        ApiTool = new ApiFuncs(projectId, secret, new HttpClient());
        UserFactory = new TestUserFactory();


        UserService = ServiceProvider.GetRequiredService<IStytchUserService>();
        MagicLinkService = ServiceProvider.GetRequiredService<IStytchMagicLinkService>();
    }

    [TearDown]
    public async Task TearDown()
    {
        await ApiTool.DeleteAllIds();
        UserFactory.ClearUsers();
    }
}