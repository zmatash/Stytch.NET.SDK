using Newtonsoft.Json;

namespace Stytch.Net.Models;

public record Name
{
    [JsonProperty("first_name")] public string? FirstName { get; set; }
    [JsonProperty("middle_name")] public string? MiddleName { get; set; }
    [JsonProperty("last_name")] public string? LastName { get; set; }
}