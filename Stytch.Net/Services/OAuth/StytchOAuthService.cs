using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common.Types;
using Stytch.Net.Services.OAuth.Models.Parameters;
using Stytch.Net.Services.OAuth.Models.Responses;

namespace Stytch.Net.Services.OAuth;

public class StytchOAuthService : BaseStytchService, IStytchOAuthService
{
    private const string Endpoint = "https://test.stytch.com/v1/oauth";
    private const string PublicEndpoint = "https://test.stytch.com/v1/public/oauth";

    public StytchOAuthService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchOAuthService> logger) : base(httpClientFactory, options, logger)
    {
    }

    public async Task<Result<AttachResponse>> Attach(AttachParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AttachResponse, AttachParameters>(HttpMethod.Post,
                parameters, $"{Endpoint}/attach");
        }
        catch (Exception ex)
        {
            return HandleException<AttachResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Google(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/google/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Amazon(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/amazon/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Apple(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/apple/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Bitbucket(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/bitbucket/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Coinbase(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/coinbase/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Discord(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/discord/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Facebook(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/facebook/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Figma(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/figma/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> GitHub(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/github/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> GitLab(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/gitlab/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> LinkedIn(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/linkedin/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Microsoft(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/microsoft/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Salesforce(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/salesforce/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Slack(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/slack/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Snapchat(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/snapchat/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> TikTok(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/tiktok/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Twitch(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/twitch/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Twitter(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/twitter/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthFlowResponse>> Yahoo(AuthFlowParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthFlowResponse, AuthFlowParameters>(HttpMethod.Get,
                parameters, $"{PublicEndpoint}/yahoo/start");
        }
        catch (Exception ex)
        {
            return HandleException<AuthFlowResponse>(ex);
        }
    }

    public async Task<Result<AuthenticateResponse>> Authenticate(AuthenticateParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthenticateResponse, AuthenticateParameters>(HttpMethod.Post,
                parameters, $"{Endpoint}/authenticate");
        }
        catch (Exception ex)
        {
            return HandleException<AuthenticateResponse>(ex);
        }
    }
}