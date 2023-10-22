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

    public async Task<Result<SendMagicLinkUserAndEmailResponse>> SendMagicLinkEmailAsync(
        SendMagicLinkEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<SendMagicLinkUserAndEmailResponse, SendMagicLinkEmailParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/send");
        }
        catch (Exception ex)
        {
            return HandleException<SendMagicLinkUserAndEmailResponse>(ex);
        }
    }

    public async Task<Result<LoginOrCreateUserUserAndEmailResponse>> LoginOrCreateUserEmailAsync(
        LoginOrCreateUserEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<LoginOrCreateUserUserAndEmailResponse, LoginOrCreateUserEmailParameters>(
                HttpMethod
                    .Post, parameters, $"{Endpoint}/login_or_create");
        }
        catch (Exception ex)
        {
            return HandleException<LoginOrCreateUserUserAndEmailResponse>(ex);
        }
    }

    public async Task<Result<InviteByUserAndEmailResponse>> InviteByEmailAsync(InviteByEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<InviteByUserAndEmailResponse, InviteByEmailParameters>(HttpMethod.Post,
                parameters,
                $"{Endpoint}/invite");
        }
        catch (Exception ex)
        {
            return HandleException<InviteByUserAndEmailResponse>(ex);
        }
    }

    public async Task<Result<RevokePendingInviteResponse>> RevokePendingInviteAsync(
        RevokePendingInviteParameters parameters)
    {
        try
        {
            return await ExecuteAsync<RevokePendingInviteResponse, RevokePendingInviteParameters>(HttpMethod.Post,
                parameters, $"{Endpoint}/revoke_invite");
        }
        catch (Exception ex)
        {
            return HandleException<RevokePendingInviteResponse>(ex);
        }
    }
}