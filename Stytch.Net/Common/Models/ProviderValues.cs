using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record ProviderValues
{
    [JsonProperty("access_token")] public string? AccessToken { get; set; }
    [JsonProperty("refresh_token")] public string? RefreshToken { get; set; }
    [JsonProperty("id_token")] public string? IdToken { get; set; }
    [JsonProperty("scopes")] public string[]? Scopes { get; set; }
    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }
}