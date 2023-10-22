using Stytch.Net.Common.Types;
using Stytch.Net.Services.MagicLinks.Models.Parameters;
using Stytch.Net.Services.MagicLinks.Models.Responses;

namespace Stytch.Net.Services.MagicLinks;

public interface IStytchMagicLinkService
{
    Task<Result<SendMagicLinkUserAndEmailResponse>> SendMagicLinkEmailAsync(SendMagicLinkEmailParameters parameters);

    Task<Result<LoginOrCreateUserUserAndEmailResponse>> LoginOrCreateUserEmailAsync(
        LoginOrCreateUserEmailParameters parameters);

    Task<Result<InviteByUserAndEmailResponse>> InviteByEmailAsync(InviteByEmailParameters parameters);
    Task<Result<RevokePendingInviteResponse>> RevokePendingInviteAsync(RevokePendingInviteParameters parameters);
}