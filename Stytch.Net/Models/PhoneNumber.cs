using Newtonsoft.Json;
using Stytch.Net.Common.Utility;

namespace Stytch.Net.Models;

public record PhoneNumber
{
    private string? _phoneNumberValue;

    [JsonProperty("phone_id")] public string? PhoneId { get; set; }

    [JsonProperty("phone_number")]
    public string? PhoneNumberValue
    {
        get => _phoneNumberValue;
        set
        {
            if (!ValidationHelpers.IsValidPhoneNumberFormat(value))
                throw new ArgumentException("Invalid phone number format. Must be in E.164 format.");

            _phoneNumberValue = value;
        }
    }

    [JsonProperty("verified")] public bool Verified { get; set; }
}