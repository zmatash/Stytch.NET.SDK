using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.SessionManagement.Models.Responses;

public class AuthenticateSessionResponse : IStytchResponse
{
    [JsonProperty("session")] public UserSession Session { get; set; }
    [JsonProperty("session_jwt")] public string SessionJwt { get; set; }
    [JsonProperty("session_token")] public string SessionToken { get; set; }
    [JsonProperty("user")] public User User { get; set; }
}