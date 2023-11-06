using Newtonsoft.Json;

namespace Stytch.Net.Services.SessionManagement.Models.Parameters;

public class AuthenticateSessionParameters
{
    [JsonProperty("session_custom_claims")]
    public Dictionary<string, object> SessionCustomClaims { get; set; }

    [JsonProperty("session_duration_minutes")]
    public int SessionDurationMinutes { get; set; }

    [JsonProperty("session_jwt")] public string SessionJwt { get; set; }
    [JsonProperty("session_token")] public string SessionToken { get; set; }
}