using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common.Types;
using Stytch.Net.Services.SessionManagement.Models.Parameters;
using Stytch.Net.Services.SessionManagement.Models.Responses;

namespace Stytch.Net.Services.SessionManagement;

public class StytchSessionManagementService : BaseStytchService, IStytchSessionManagementService
{
    private const string Endpoint = "https://test.stytch.com/v1/sessions";
    private readonly StytchConfiguration _stytchConfig;

    public StytchSessionManagementService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchSessionManagementService> logger) : base(httpClientFactory, options,
        logger)
    {
        _stytchConfig = options.Value;
    }

    public async Task<Result<GetJWKSResponse>> GetJWKS(GetJWKSParameters parameters)
    {
        try
        {
            return await ExecuteAsync<GetJWKSResponse, GetJWKSParameters>(HttpMethod.Get, parameters,
                $"{Endpoint}/jwks/{_stytchConfig.ProjectId}");
        }
        catch (Exception ex)
        {
            return HandleException<GetJWKSResponse>(ex);
        }
    }

    public async Task<Result<GetSessionsResponse>> GetSessions(GetSessionsParameters parameters)
    {
        try
        {
            return await ExecuteAsync<GetSessionsResponse, GetSessionsParameters>(HttpMethod.Get, parameters,
                Endpoint);
        }
        catch (Exception ex)
        {
            return HandleException<GetSessionsResponse>(ex);
        }
    }

    public async Task<Result<AuthenticateSessionResponse>> AuthenticateSession(AuthenticateSessionParameters parameters)
    {
        try
        {
            return await ExecuteAsync<AuthenticateSessionResponse, AuthenticateSessionParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/authenticate");
        }
        catch (Exception ex)
        {
            return HandleException<AuthenticateSessionResponse>(ex);
        }
    }

    public async Task<Result<RevokeSessionResponse>> RevokeSession(RevokeSessionParameters parameters)
    {
        try
        {
            return await ExecuteAsync<RevokeSessionResponse, RevokeSessionParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/revoke");
        }
        catch (Exception ex)
        {
            return HandleException<RevokeSessionResponse>(ex);
        }
    }
}