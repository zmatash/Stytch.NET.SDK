using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common.Types;
using Stytch.Net.Services.MagicLinks.Models.Parameters;
using Stytch.Net.Services.MagicLinks.Models.Responses;

namespace Stytch.Net.Services.MagicLinks;

public class StytchMagicLinkService : BaseStytchService, IStytchMagicLinkService
{
    private const string Endpoint = "https://test.stytch.com/v1/magic_links/email";

    public StytchMagicLinkService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchMagicLinkService> logger) : base(httpClientFactory, options, logger)
    {
    }

    public async Task<Result<SendEmailResponse>> SendEmailAsync(SendEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<SendEmailResponse, SendEmailParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/send");
        }
        catch (Exception ex)
        {
            return HandleException<SendEmailResponse>(ex);
        }
    }

    public async Task<Result<LoginOrCreateUserResponse>> LoginOrCreateUserAsync(
        LoginOrCreateUserParameters parameters)
    {
        try
        {
            return await ExecuteAsync<LoginOrCreateUserResponse, LoginOrCreateUserParameters>(
                HttpMethod
                    .Post, parameters, $"{Endpoint}/login_or_create");
        }
        catch (Exception ex)
        {
            return HandleException<LoginOrCreateUserResponse>(ex);
        }
    }

    public async Task<Result<InviteResponse>> InviteAsync(InviteParameters parameters)
    {
        try
        {
            return await ExecuteAsync<InviteResponse, InviteParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/invite");
        }
        catch (Exception ex)
        {
            return HandleException<InviteResponse>(ex);
        }
    }

    public async Task<Result<RevokeResponse>> RevokeInviteAsync(RevokeInviteParameters parameters)
    {
        try
        {
            return await ExecuteAsync<RevokeResponse, RevokeInviteParameters>(HttpMethod.Post,
                parameters, $"{Endpoint}/revoke_invite");
        }
        catch (Exception ex)
        {
            return HandleException<RevokeResponse>(ex);
        }
    }
}