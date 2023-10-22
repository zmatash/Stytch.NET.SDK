using System.Text.RegularExpressions;

namespace Stytch.Net.Utility.DataValidation;

public static class PhoneNumberValidator
{
    public static string? FormatPhoneNumber(string? phoneNumber)
    {
        string? formattedNumber = phoneNumber.Replace(" ", "");
        if (!formattedNumber.StartsWith("+")) formattedNumber = "+" + formattedNumber;

        return formattedNumber;
    }

    public static bool IsValidPhoneNumberFormat(string? phoneNumber)
    {
        Regex regex = new(@"^\+[1-9]\d{1,14}$");
        if (!string.IsNullOrEmpty(phoneNumber) && regex.IsMatch(phoneNumber)) return true;

        return false;
    }
}