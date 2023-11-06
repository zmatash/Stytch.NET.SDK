using Newtonsoft.Json;
using Stytch.Net.Common.Models.Properties.PropertyGroups;

namespace Stytch.Net.Services.MagicLinks.Models.Responses;

public record LoginOrCreateUserResponse : UserAndEmailId, IStytchResponse
{
    [JsonProperty("user_created")] public bool UserCreated { get; set; }
}