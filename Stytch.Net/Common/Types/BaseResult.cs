using Newtonsoft.Json;

namespace Stytch.Net.Common.Types;

public abstract record BaseResult
{
    [JsonProperty("request_id")] public string? RequestId { get; set; }
    [JsonProperty("status_code")] public int StatusCode { get; set; }
    public bool IsSuccessStatusCode => StatusCode is >= 200 and < 300;
}