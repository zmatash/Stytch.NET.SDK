using Newtonsoft.Json;
using Stytch.Net.Common;
using Stytch.Net.Common.PropertyBaseClasses;

namespace Stytch.Net.StytchService.Models.Responses;

public record LoginOrCreateUserEmailResponse : EmailAndUserIdProperty, IStytchResponse
{
    [JsonProperty("user_created")] public bool UserCreated { get; set; }
}