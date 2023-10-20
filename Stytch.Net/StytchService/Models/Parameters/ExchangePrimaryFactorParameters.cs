using Newtonsoft.Json;
using Stytch.Net.Common.PropertyBaseClasses;

namespace Stytch.Net.StytchService.Models.Parameters;

public record ExchangePrimaryFactorParameters : PhoneNumberProperty
{
    public ExchangePrimaryFactorParameters()
    {
        if (!string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(PhoneNumberValue))
            throw new ArgumentException("Email address and phone number cannot both be specified at the same time.");
    }

    [JsonProperty("email_address")] public string? EmailAddress { get; set; }
}