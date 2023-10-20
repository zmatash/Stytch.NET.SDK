using Newtonsoft.Json;
using Stytch.Net.Common.PropertyBaseClasses;

namespace Stytch.Net.Models;

public record PhoneNumber : PhoneNumberProperty
{
    [JsonProperty("phone_id")] public string? PhoneId { get; set; }
    [JsonProperty("verified")] public bool Verified { get; set; }
}