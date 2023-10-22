using Newtonsoft.Json;
using Stytch.Net.Common.Models;
using Stytch.Net.Utility.DataValidation;

namespace Stytch.Net.Services.Users.Models.Responses;

public record ExchangePrimaryFactorResponse : IStytchResponse
{
    private string? _phoneNumber;
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }

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