using System.Text.RegularExpressions;

namespace Stytch.Net.Common.Utility;

public static class ValidationHelpers
{
    public static bool IsValidPhoneNumberFormat(string? phoneNumber)
    {
        Regex regex = new(@"^\+[1-9]\d{1,14}$");
        if (phoneNumber != null && !regex.IsMatch(phoneNumber))
        {
            return true;
        }

        return false;
    }
}