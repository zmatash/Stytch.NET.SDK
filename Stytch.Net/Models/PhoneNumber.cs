using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record PhoneNumber
{
    [JsonProperty("phone_id")] public string? PhoneId { get; set; }
    [JsonProperty("phone_number")] public string? PhoneNumberValue { get; set; }
    [JsonProperty("verified")] public bool Verified { get; set; }
}