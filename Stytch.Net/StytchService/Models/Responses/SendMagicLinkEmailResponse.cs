using Stytch.Net.Common;
using Stytch.Net.Common.PropertyBaseClasses;

namespace Stytch.Net.StytchService.Models.Responses;

public record SendMagicLinkEmailResponse : EmailAndUserIdProperty, IStytchResponse
{
}