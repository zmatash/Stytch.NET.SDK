using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.OAuth.Models.Responses;

public class AuthenticateResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string UserId { get; set; }
    [JsonProperty("user")] public User User { get; set; }

    [JsonProperty("oauth_user_registration_id")]
    public string OAuthUserRegistrationId { get; set; }

    [JsonProperty("provider_subject")] public string ProviderSubject { get; set; }
    [JsonProperty("provider_type")] public string ProviderType { get; set; }
    [JsonProperty("provider_values")] public ProviderValues ProviderValues { get; set; } // TODO: Add type
    [JsonProperty("reset_sessions")] public bool ResetSessions { get; set; }
    [JsonProperty("user_session")] public UserSession UserSession { get; set; } // TODO: Add type
    [JsonProperty("session_token")] public string SessionToken { get; set; }
    [JsonProperty("session_jwt")] public string SessionJwt { get; set; }
}