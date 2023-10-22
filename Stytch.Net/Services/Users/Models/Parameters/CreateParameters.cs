using Newtonsoft.Json;
using Stytch.Net.Common.Models;
using Stytch.Net.Utility.DataValidation;

namespace Stytch.Net.Services.Users.Models.Parameters;

public record CreateParameters
{
    private string? _phoneNumber;
    [JsonProperty("email")] public string? Email { get; set; }
    [JsonProperty("name")] public Name? Name { get; set; }

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

    [JsonProperty("trusted_metadata")] public Dictionary<string, string>? TrustedMetadata { get; set; }
    [JsonProperty("untrusted_metadata")] public Dictionary<string, string>? UntrustedMetadata { get; set; }
    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }

    [JsonProperty("create_user_as_pending")]
    public bool CreateUserAsPending { get; set; }
}