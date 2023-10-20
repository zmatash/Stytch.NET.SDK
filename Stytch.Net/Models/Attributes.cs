using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record Attributes
{
    [JsonProperty("ip_address")] private string? IpAddress { get; set; }
    [JsonProperty("user_agent")] private string? UserAgent { get; set; }
}