using Stytch.Net.Common.Models.Properties.PropertyGroups;

namespace Stytch.Net.Services.MagicLinks.Models.Responses;

public record SendMagicLinkUserAndEmailResponse : UserAndEmailId, IStytchResponse
{
}