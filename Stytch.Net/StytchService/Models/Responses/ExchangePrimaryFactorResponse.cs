using Newtonsoft.Json;
using Stytch.Net.Common;
using Stytch.Net.Common.PropertyBaseClasses;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Responses;

public record ExchangePrimaryFactorResponse : PhoneNumberProperty, IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
}