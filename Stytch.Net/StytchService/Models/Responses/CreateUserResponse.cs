using Newtonsoft.Json;
using Stytch.Net.Common;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Responses;

public record CreateUserResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
    [JsonProperty("email_id")] public string? EmailId { get; set; }
    [JsonProperty("phone_id")] public string? PhoneId { get; set; }
    [JsonProperty("status")] public string? Status { get; set; }
}