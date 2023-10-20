using Newtonsoft.Json;

namespace Stytch.Net.Models;

public class ApiErrorInfo
{
    [JsonProperty("error_type")] public string? ErrorType { get; set; }
    [JsonProperty("error_message")] public string? ErrorMessage { get; set; }
    [JsonProperty("error_url")] public string? ErrorUrl { get; set; }
}