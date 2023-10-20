using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stytch.Net.Models;

public enum StatusEnum
{
    [EnumMember(Value = "active")] Active,
    [EnumMember(Value = "pending")] Pending
}

public interface IOperandValue
{
}

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
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class FullNameFuzzyValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "full_name_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class Status
    {
        [JsonProperty("filter_name")] private const string FilterName = "status";

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("filter_value")]
        public StatusEnum FilterValue { get; set; }
    }

    public class PhoneNumberValue
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_number";

        private string[]? _filterValue;

        [JsonProperty("filter_value")]
        public string[]? FilterValue
        {
            get => _filterValue;
            set
            {
                Regex regex = new(@"^\+[1-9]\d{1,14}$");
                if (value != null && value.Any(phoneNumber => !regex.IsMatch(phoneNumber)))
                    throw new ArgumentException("Invalid phone number format. Must be in E.164 format.");
                _filterValue = value;
            }
        }
    }

    public class PhoneNumberFuzzy
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_number_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class PhoneId
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class PhoneVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "phone_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class EmailAddress
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_address";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class EmailAddressFuzzy
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_address_fuzzy";
        [JsonProperty("filter_value")] public string? FilterValue { get; set; }
    }

    public class EmailId
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class EmailVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "email_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class OAuthProvider
    {
        [JsonProperty("filter_name")] private const string FilterName = "oauth_provider";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class WebAuthnRegistrationId
    {
        [JsonProperty("filter_name")] private const string FilterName = "webauthn_registration_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class WebAuthnRegistrationVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "webauthn_registration_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class BiometricRegistrationId
    {
        [JsonProperty("filter_name")] private const string FilterName = "biometric_registration_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class BiometricRegistrationVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "biometric_registration_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class TotpId
    {
        [JsonProperty("filter_name")] private const string FilterName = "totp_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class TotpIdVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "totp_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class CryptoWalletId
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_id";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class CryptoWalletAddress
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_address";
        [JsonProperty("filter_value")] public string[]? FilterValue { get; set; }
    }

    public class CryptoWalletVerified
    {
        [JsonProperty("filter_name")] private const string FilterName = "crypto_wallet_verified";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }

    public class PasswordExists
    {
        [JsonProperty("filter_name")] private const string FilterName = "password_exists";
        [JsonProperty("filter_value")] public bool FilterValue { get; set; }
    }
}