using Newtonsoft.Json;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Parameters;

public record CreateUserParameters
{
    [JsonProperty("email")] public string? Email { get; set; }
    [JsonProperty("phone_number")] public string? PhoneNumber { get; set; }
    [JsonProperty("name")] public Name? Name { get; set; }
    [JsonProperty("trusted_metadata")] public Dictionary<string, string>? TrustedMetadata { get; set; }
    [JsonProperty("untrusted_metadata")] public Dictionary<string, string>? UntrustedMetadata { get; set; }
    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }

    [JsonProperty("create_user_as_pending")]
    public bool CreateUserAsPending { get; set; }
}