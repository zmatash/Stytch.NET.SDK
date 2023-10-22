using Newtonsoft.Json;
using Stytch.Net.Utility.DataValidation;

namespace Stytch.Net.Services.Users.Models.Parameters;

public record ExchangePrimaryFactorParameters
{
    private string? _phoneNumber;

    public ExchangePrimaryFactorParameters()
    {
        if (!string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(_phoneNumber))
            throw new ArgumentException("Email address and phone number cannot both be specified at the same time.");
    }

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

    [JsonProperty("email_address")] public string? EmailAddress { get; set; }
}