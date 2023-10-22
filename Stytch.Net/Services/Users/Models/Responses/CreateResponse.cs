using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Responses;

public record CreateResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
    [JsonProperty("email_id")] public string? EmailId { get; set; }
    [JsonProperty("phone_id")] public string? PhoneId { get; set; }
    [JsonProperty("status")] public string? Status { get; set; }
}