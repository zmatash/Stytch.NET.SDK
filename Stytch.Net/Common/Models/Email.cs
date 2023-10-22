using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record Email
{
    [JsonProperty("email_id")] public string? EmailId { get; set; }
    [JsonProperty("email")] public string? EmailValue { get; set; }
    [JsonProperty("verified")] public string? Verified { get; set; }
}