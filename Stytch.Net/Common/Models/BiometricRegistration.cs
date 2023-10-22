using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record BiometricRegistration
{
    [JsonProperty("biometric_registration_id")]
    public string? BiometricRegistrationId { get; set; }

    [JsonProperty("verified")] public bool Verified { get; set; }
}