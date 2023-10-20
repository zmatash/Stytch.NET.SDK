using Newtonsoft.Json;

namespace Stytch.Net.Models;

public class Error
{
    [JsonProperty("status_code")] public int StatusCode { get; set; }
    [JsonProperty("request_id")] public string? RequestId { get; set; }
    [JsonProperty("error_type")] public string? ErrorType { get; set; }
    [JsonProperty("error_message")] public string? ErrorMessage { get; set; }
    [JsonProperty("error_url")] public string? ErrorUrl { get; set; }
}