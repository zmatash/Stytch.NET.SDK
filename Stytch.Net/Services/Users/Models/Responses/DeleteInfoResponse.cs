using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Responses;

public record DeleteInfoResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
}