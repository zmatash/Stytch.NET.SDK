using Newtonsoft.Json;

namespace Stytch.Net.Common.Models.Properties.PropertyGroups;

public abstract record UserAndEmailId
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("email_id")] public string? EmailId { get; set; }
}