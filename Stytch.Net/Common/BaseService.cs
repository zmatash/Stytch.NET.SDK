using Microsoft.Extensions.Options;

namespace Stytch.Net.Common;

public abstract class BaseService
{
    protected readonly StytchConfiguration Config;
    protected readonly HttpClient HttpClient;

    protected BaseService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options)
    {
        HttpClient = httpClientFactory.CreateClient();
        Config = options.Value;
    }
}