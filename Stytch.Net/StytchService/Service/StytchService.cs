using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService : BaseService, IStytchService
{
    private const string BaseApi = "https://test.stytch.com/v1/users";
    private readonly ILogger<StytchService> _logger;

    public StytchService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchService> logger) : base(httpClientFactory, options)
    {
        _logger = logger;
    }
}