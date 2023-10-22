using Newtonsoft.Json;
using Stytch.Net.Utility.DataValidation;

namespace Stytch.Net.Common.Models;

public record Phone
{
    private string? _phoneNumber;

    [JsonProperty("phone_id")] public string? PhoneId { get; set; }
    [JsonProperty("verified")] public bool Verified { get; set; }

    [JsonProperty("phone_number")]
    public string? PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (value != null)
            {
                string? formattedNumber = PhoneNumberValidator.FormatPhoneNumber(value);
                if (!PhoneNumberValidator.IsValidPhoneNumberFormat(formattedNumber))
                    throw new ArgumentException("Invalid phone number format. Must be in E.164 format.");
                _phoneNumber = formattedNumber;
            }
        }
    }
}