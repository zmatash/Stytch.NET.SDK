using Stytch.Net.IntegrationTests.Resources.Utility;

namespace Stytch.Net.IntegrationTests.Resources.Data;

public class TestUser
{
    public string Email { get; set; } = GenerateRandomEmail();
    public string FirstName { get; set; } = GenerateRandomName();
    public string MiddleName { get; set; } = GenerateRandomName();
    public string LastName { get; set; } = GenerateRandomName();
    public string PhoneNumber { get; set; } = GenerateRandomPhoneNumber();

    private static string GenerateRandomEmail()
    {
        // ReSharper disable once StringLiteralTypo
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = HelperFuncs.RandomStringGen(chars, 7);

        return new string(randomString) + "@FakeEmail.com";
    }

    private static string GenerateRandomName()
    {
        // ReSharper disable once StringLiteralTypo
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string randomString = HelperFuncs.RandomStringGen(chars, 7);

        return new string(randomString);
    }

    private static string GenerateRandomPhoneNumber()
    {
        const string chars = "0123456789";
        string randomString = HelperFuncs.RandomStringGen(chars, 10);
        return $"+{randomString}";
    }

    // ReSharper disable once CommentTypo
    /*public static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&#1#";
        string randomString = HelperFuncs.RandomStringGen(chars, 10);

        return new string(randomString);
    }*/
}