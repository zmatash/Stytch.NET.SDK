using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService
{
    public async Task<StytchResult<SendMagicLinkEmailResponse>> SendMagicLinkEmailAsync(
        SendMagicLinkEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<SendMagicLinkEmailResponse, SendMagicLinkEmailParameters>(HttpMethod.Post,
                parameters,
                $"{MagicLinkApi}/send");
        }
        catch (Exception ex)
        {
            return HandleException<SendMagicLinkEmailResponse>(ex);
        }
    }

    public async Task<StytchResult<LoginOrCreateUserEmailResponse>> LoginOrCreateUserEmailAsync(
        LoginOrCreateUserEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<LoginOrCreateUserEmailResponse, LoginOrCreateUserEmailParameters>(HttpMethod
                    .Post, parameters, $"{MagicLinkApi}/login_or_create");
        }
        catch (Exception ex)
        {
            return HandleException<LoginOrCreateUserEmailResponse>(ex);
        }
    }

    public async Task<StytchResult<InviteByEmailResponse>> InviteByEmailAsync(InviteByEmailParameters parameters)
    {
        try
        {
            return await ExecuteAsync<InviteByEmailResponse, InviteByEmailParameters>(HttpMethod.Post, parameters,
                $"{MagicLinkApi}/invite");
        }
        catch (Exception ex)
        {
            return HandleException<InviteByEmailResponse>(ex);
        }
    }

    public async Task<StytchResult<RevokePendingInviteResponse>> RevokePendingInviteAsync(
        RevokePendingInviteParameters parameters)
    {
        try
        {
            return await ExecuteAsync<RevokePendingInviteResponse, RevokePendingInviteParameters>(HttpMethod.Post,
                parameters, $"{MagicLinkApi}/revoke_invite");
        }
        catch (Exception ex)
        {
            return HandleException<RevokePendingInviteResponse>(ex);
        }
    }
}