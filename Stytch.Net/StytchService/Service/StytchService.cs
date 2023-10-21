using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common;
using Stytch.Net.Common.Utility;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService : BaseService, IStytchService
{
    private const string UsersApi = "https://test.stytch.com/v1/users";
    private const string MagicLinkApi = "https://test.stytch.com/v1/magic_links/email";
    private readonly ILogger<StytchService> _logger;

    public StytchService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchService> logger) : base(httpClientFactory, options)
    {
        _logger = logger;
    }

    private async Task<StytchResult<T>> ExecuteAsync<T, TU>(HttpMethod method, TU parameters, string url) where T :
        class, IStytchResponse
    {
        HttpRequestMessage request = ApiUtils.CreateRequest(method, url, parameters, Config);
        HttpResponseMessage response = await HttpClient.SendAsync(request).ConfigureAwait(false);
        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return ApiUtils.CreateStytchResult<T>(response, json);
    }

    private StytchResult<T> HandleException<T>(Exception ex) where T : IStytchResponse
    {
        _logger.Log(LogLevel.Error, "Error: {Ex}", ex);
        return new StytchResult<T>
        {
            StatusCode = 500,
            ApiErrorInfo = new ApiErrorInfo
            {
                ErrorMessage = $"Internal Server ApiErrorInfo: {ex}"
            }
        };
    }
}