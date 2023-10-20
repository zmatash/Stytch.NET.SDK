using Newtonsoft.Json;

namespace Stytch.Net.Models;

public class ResultsMetaData
{
    [JsonProperty("next_cursor")] public string? NextCursor { get; set; }
    [JsonProperty("total")] public int Total { get; set; }
}