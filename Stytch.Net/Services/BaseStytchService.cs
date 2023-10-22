using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common.Models;
using Stytch.Net.Common.Types;
using Stytch.Net.Utility;

namespace Stytch.Net.Services;

public abstract class BaseStytchService
{
    private readonly ILogger<BaseStytchService> _logger;
    protected readonly StytchConfiguration Config;
    protected readonly HttpClient HttpClient;

    protected BaseStytchService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<BaseStytchService> logger)
    {
        HttpClient = httpClientFactory.CreateClient();
        Config = options.Value;
        _logger = logger;
    }

    protected async Task<Result<T>> ExecuteAsync<T, TU>(HttpMethod method, TU? parameters, string url) where T :
        class, IStytchResponse
    {
        HttpRequestMessage request = HttpUtils.CreateRequest(method, url, parameters, Config);
        HttpResponseMessage response = await HttpClient.SendAsync(request).ConfigureAwait(false);
        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return HttpUtils.CreateResult<T>(response, json);
    }

    protected Result<T> HandleException<T>(Exception ex) where T : IStytchResponse
    {
        _logger.Log(LogLevel.Error, "Error: {Ex}", ex);
        return new Result<T>
        {
            StatusCode = 500,
            ApiErrorInfo = new ApiErrorInfo
            {
                ErrorMessage = $"Internal Server ApiErrorInfo: {ex}"
            }
        };
    }
}