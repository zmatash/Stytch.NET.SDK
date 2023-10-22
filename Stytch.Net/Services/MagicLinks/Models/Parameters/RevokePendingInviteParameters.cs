using Newtonsoft.Json;

namespace Stytch.Net.Services.MagicLinks.Models.Parameters;

public record RevokePendingInviteParameters
{
    [JsonProperty("email")] public string Email { get; set; } = null!;
}