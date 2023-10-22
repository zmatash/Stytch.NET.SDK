using System.Text.RegularExpressions;

namespace Stytch.Net.Utility.DataValidation;

internal static class PhoneNumberValidator
{
    internal static string? FormatPhoneNumber(string? phoneNumber)
    {
        string? formattedNumber = phoneNumber.Replace(" ", "");
        if (!formattedNumber.StartsWith("+")) formattedNumber = "+" + formattedNumber;

        return formattedNumber;
    }

    internal static bool IsValidPhoneNumberFormat(string? phoneNumber)
    {
        Regex regex = new(@"^\+[1-9]\d{1,14}$");
        if (!string.IsNullOrEmpty(phoneNumber) && regex.IsMatch(phoneNumber)) return true;

        return false;
    }
}