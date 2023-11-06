using Newtonsoft.Json;

namespace Stytch.Net.Services.OAuth.Models.Responses;

public class AttachResponse : IStytchResponse
{
    [JsonProperty("oauth_attach_token")] public string OAuthAttachToken { get; set; }
}