using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Parameters;

public record UpdateParameters
{
    [JsonProperty("name")] public Name? Name { get; set; }
    [JsonProperty("trusted_metadata")] public Dictionary<string, string>? TrustedMetadata { get; set; }
    [JsonProperty("untrusted_metadata")] public Dictionary<string, string>? UntrustedMetadata { get; set; }
    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }
}