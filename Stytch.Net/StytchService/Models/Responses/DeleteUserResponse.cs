using Newtonsoft.Json;
using Stytch.Net.Common;

namespace Stytch.Net.StytchService.Models.Responses;

public record DeleteUserResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
}