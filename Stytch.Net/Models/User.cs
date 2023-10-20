using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record User
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("name")] public Name? Name { get; set; }
    [JsonProperty("emails")] public Email[] Emails { get; set; } = null!;
    [JsonProperty("phone_numbers")] public PhoneNumber[]? PhoneNumbers { get; set; }
    [JsonProperty("providers")] public Provider[]? Providers { get; set; }

    [JsonProperty("webauthn_registrations")]
    public WebAuthnRegistration[]? WebAuthnRegistrations { get; set; }

    [JsonProperty("biometric_registrations")]
    public BiometricRegistration[]? BiometricRegistrations { get; set; }

    [JsonProperty("totps")] public Totp[]? Totps { get; set; }
    [JsonProperty("crypto_wallets")] public CryptoWallet[]? CryptoWallets { get; set; }
    [JsonProperty("password")] public Password? Password { get; set; }
    [JsonProperty("created_at")] public string? CreatedAt { get; set; }
    [JsonProperty("status")] public string? Status { get; set; }
    [JsonProperty("trusted_metadata")] public Dictionary<string, string>? TrustedMetadata { get; set; }
    [JsonProperty("untrusted_metadata")] public Dictionary<string, string>? UntrustedMetadata { get; set; }
}