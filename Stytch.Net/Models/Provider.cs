using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record Provider
{
    [JsonProperty("oauth_user_registration_id")]
    public string? OauthUserRegistrationId { get; set; }

    [JsonProperty("provider_subject")] public string? ProviderSubject { get; set; }
    [JsonProperty("provider_type")] public string? ProviderType { get; set; }
    [JsonProperty("profile_picture_url")] public string? ProfilePictureUrl { get; set; }
    [JsonProperty("locale")] public string? Locale { get; set; }
}