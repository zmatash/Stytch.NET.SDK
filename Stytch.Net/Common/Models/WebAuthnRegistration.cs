using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record WebAuthnRegistration
{
    [JsonProperty("authenticator_type")] public string? AuthenticatorType;
    [JsonProperty("domain")] public string? Domain;
    [JsonProperty("user_agent")] public string? UserAgent;
    [JsonProperty("verified")] public bool Verified;

    [JsonProperty("webauthn_registration_id")]
    public string? WebAuthnRegistrationId;
}