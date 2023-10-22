using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Parameters;

public record SearchParameters
{
    [JsonProperty("limit")] public int Limit { get; set; } = 100;
    [JsonProperty("cursor")] public string? Cursor { get; set; }
    [JsonProperty("query")] public Query? Query { get; set; }
}