using Newtonsoft.Json;

namespace Stytch.Net.Services.SessionManagement.Models.Parameters;

public class RevokeSessionParameters
{
    [JsonProperty("session_id")] public string SessionId { get; set; }
    [JsonProperty("session_jwt")] public string SessionJwt { get; set; }
    [JsonProperty("session_token")] public string SessionToken { get; set; }
}