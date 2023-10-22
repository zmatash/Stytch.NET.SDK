using Newtonsoft.Json;

namespace Stytch.Net.Services.Users.Models.Responses;

public record DeleteResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
}