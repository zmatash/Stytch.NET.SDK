using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record Password
{
    [JsonProperty("password_id")] public string PasswordId { get; set; } = "";
    [JsonProperty("requires_reset")] public string RequiresReset { get; set; } = "";
}