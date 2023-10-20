using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record Totp
{
    [JsonProperty("totp_id")] public string? TotpId { get; set; }
    [JsonProperty("verified")] public bool Verified { get; set; }
}