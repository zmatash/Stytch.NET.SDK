using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record UserSession
{
    [JsonProperty("session_id")] public string? SessionId { get; set; }
    [JsonProperty("user_id")] public string? UserId { get; set; }

    [JsonProperty("authentication_factors")]
    public object[] AuthenticationFactors { get; set; }

    [JsonProperty("started_at")] public string? StartedAt { get; set; }
    [JsonProperty("last_accessed_at")] public string? LastAccessedAt { get; set; }
    [JsonProperty("expires_at")] public string? ExpiresAt { get; set; }
    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }
    [JsonProperty("custom_claims")] public Dictionary<string, object>? CustomClaims { get; set; }
}