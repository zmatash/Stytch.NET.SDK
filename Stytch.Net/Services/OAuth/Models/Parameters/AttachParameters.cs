using Newtonsoft.Json;

namespace Stytch.Net.Services.OAuth.Models.Parameters;

public class AttachParameters
{
    [JsonProperty("provider")] public string Provider { get; set; }
    [JsonProperty("user_id")] public string UserId { get; set; }
    [JsonProperty("session_token")] public string SessionToken { get; set; }
    [JsonProperty("session_jwt")] public string SessionJwt { get; set; }
}