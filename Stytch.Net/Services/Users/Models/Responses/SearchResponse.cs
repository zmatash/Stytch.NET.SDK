using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Responses;

public record SearchResponse : IStytchResponse
{
    [JsonProperty("results")] public User[] Results { get; set; } = null!;
    [JsonProperty("results_metadata")] public ResultsMetaData ResultsMetaData { get; set; } = null!;
}