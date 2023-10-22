using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stytch.Net.Utility.DataValidation;

namespace Stytch.Net.Common.Models;

public enum StatusEnum
{
    [EnumMember(Value = "active")] Active,
    [EnumMember(Value = "pending")] Pending
}

public interface IOperandValue
{
}

/// <summary>
///     Use like this: new Operand.EmailAddress {FilterValue = new[] {testUser.Email}}
///     Or similar.
/// </summary>
public class Operand
{
    public class CreatedAtBetweenValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "created_at_between";
        [JsonProperty("filter_value")] public CreatedAtBetween? FilterValue { get; set; }
    }

    public class CreatedAtGreaterThanValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "created_at_greater_than";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class CreatedAtLessThanValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "created_at_less_than";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class UserIdValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "user_id";
        [JsonProperty("filter_value")] public string?[] FilterValue { get; set; }
    }

    public class FullNameFuzzyValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "full_name_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class Status : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "status";

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("filter_value")]
        public StatusEnum FilterValue { get; set; }
    }

    public class PhoneNumberValue : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_number";

        private string?[]? _filterValue;

        [JsonProperty("filter_value")]
        public string?[]? FilterValue
        {
            get => _filterValue;
            set
            {
                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        string? phoneNumber = value[i];
                        string? formattedNumber = PhoneNumberValidator.FormatPhoneNumber(phoneNumber);
                        if (!PhoneNumberValidator.IsValidPhoneNumberFormat(formattedNumber))
                            throw new ArgumentException("Invalid phone number format. Must be in E.164 format.");
                        value[i] = formattedNumber;
                    }

                    _filterValue = value;
                }
            }
        }
    }

    public class PhoneNumberFuzzy : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_number_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class PhoneId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class PhoneVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class EmailAddress : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_address";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class EmailAddressFuzzy : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_address_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class EmailId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class EmailVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class OAuthProvider : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "oauth_provider";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class WebAuthnRegistrationId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "webauthn_registration_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class WebAuthnRegistrationVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "webauthn_registration_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class BiometricRegistrationId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "biometric_registration_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class BiometricRegistrationVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "biometric_registration_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class TotpId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "totp_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class TotpIdVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "totp_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class CryptoWalletId : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class CryptoWalletAddress : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_address";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class CryptoWalletVerified : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class PasswordExists : IOperandValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "password_exists";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }
}