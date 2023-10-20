using Newtonsoft.Json;
using Stytch.Net.Common;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Responses;

public record SearchUsersResponse : BaseResponse
{
    [JsonProperty("results")] public User[] Results { get; set; } = null!;
    [JsonProperty("results_metadata")] public ResultsMetaData ResultsMetaData { get; set; } = null!;
}