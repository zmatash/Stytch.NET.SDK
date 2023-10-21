using Newtonsoft.Json;

namespace Stytch.Net.Common.PropertyBaseClasses;

public abstract record EmailAndUserIdProperty
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("email_id")] public string? EmailId { get; set; }
}