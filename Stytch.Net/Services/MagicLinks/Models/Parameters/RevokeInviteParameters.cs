using Newtonsoft.Json;

namespace Stytch.Net.Services.MagicLinks.Models.Parameters;

public record RevokeInviteParameters
{
    [JsonProperty("email")] public string Email { get; set; } = null!;
}