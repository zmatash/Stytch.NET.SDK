using Newtonsoft.Json;

namespace Stytch.Net.Services.SessionManagement.Models.Responses;

public class GetJWKSResponse : IStytchResponse
{
    [JsonProperty("keys")] public object Keys { get; set; }
}