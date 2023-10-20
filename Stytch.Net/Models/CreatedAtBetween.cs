using Newtonsoft.Json;

namespace Stytch.Net.Models;

public class CreatedAtBetween
{
    [JsonProperty("greater_than")] public string? GreaterThan { get; set; }
    [JsonProperty("less_than")] public string? LessThan { get; set; }
}