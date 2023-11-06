using Stytch.Net.Common.Types;
using Stytch.Net.Services.MagicLinks.Models.Parameters;
using Stytch.Net.Services.MagicLinks.Models.Responses;

namespace Stytch.Net.Services.MagicLinks;

public interface IStytchMagicLinkService
{
    Task<Result<SendEmailResponse>> SendEmailAsync(SendEmailParameters parameters);

    Task<Result<LoginOrCreateUserResponse>> LoginOrCreateUserAsync(
        LoginOrCreateUserParameters parameters);

    Task<Result<InviteResponse>> InviteAsync(InviteParameters parameters);
    Task<Result<RevokeResponse>> RevokeInviteAsync(RevokeInviteParameters parameters);
}