using Stytch.Net.IntegrationTests.Resources.Utility;

namespace Stytch.Net.IntegrationTests.Resources.Data;

public class TestUser
{
    public string Email { get; set; } = GenerateRandomEmail();
    public string FirstName { get; set; } = GenerateRandomName();
    public string MiddleName { get; set; } = GenerateRandomName();
    public string LastName { get; set; } = GenerateRandomName();
    public string? UserId { get; set; }


    private static string GenerateRandomEmail()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = HelperFuncs.RandomStringGen(chars, 7);

        return new string(randomString) + "@FakeEmail.com";
    }

    private static string GenerateRandomName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string randomString = HelperFuncs.RandomStringGen(chars, 7);

        return new string(randomString);
    }

    public static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*/";
        string randomString = HelperFuncs.RandomStringGen(chars, 10);

        return new string(randomString);
    }
}