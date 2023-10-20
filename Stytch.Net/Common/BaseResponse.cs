using Newtonsoft.Json;

namespace Stytch.Net.Common;

public record BaseResponse : IStytchResponse
{
    [JsonProperty("request_id")] public string? RequestId { get; set; }
    [JsonProperty("status_code")] public int StatusCode { get; set; }
}