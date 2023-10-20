using Newtonsoft.Json;
using Stytch.Net.Common.Utility;

namespace Stytch.Net.Common.PropertyBaseClasses;

public abstract record PhoneNumberProperty
{
    private string? _phoneNumberValue;

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
}