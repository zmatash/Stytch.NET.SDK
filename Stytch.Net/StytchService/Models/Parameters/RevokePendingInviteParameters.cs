using Newtonsoft.Json;

namespace Stytch.Net.StytchService.Models.Parameters;

public record RevokePendingInviteParameters
{
    [JsonProperty("email")] public string Email { get; set; } = null!;
}