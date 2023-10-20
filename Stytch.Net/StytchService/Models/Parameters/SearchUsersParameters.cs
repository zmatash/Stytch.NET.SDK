using Newtonsoft.Json;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Parameters;

public class SearchUsersParameters
{
    [JsonProperty("limit")] public int Limit { get; set; } = 100;
    [JsonProperty("cursor")] public string? Cursor { get; set; }
    [JsonProperty("query")] public Query? Query { get; set; }
}