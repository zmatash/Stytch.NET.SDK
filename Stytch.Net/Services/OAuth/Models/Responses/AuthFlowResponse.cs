using Newtonsoft.Json;

namespace Stytch.Net.Services.OAuth.Models.Responses;

public class AuthFlowResponse : IStytchResponse
{
    [JsonProperty("redirect_url")] public string RedirectUrl { get; set; }
}