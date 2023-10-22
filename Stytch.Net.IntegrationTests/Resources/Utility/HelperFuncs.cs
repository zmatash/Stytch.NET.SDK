using System.Collections;

namespace Stytch.Net.IntegrationTests.Resources.Utility;

public static class HelperFuncs
{
    public static string RandomStringGen(string allowedChars, int stringLength)
    {
        Random random = new();
        char[] stringChars = new char[stringLength];

        for (int i = 0; i < stringLength; i++) stringChars[i] = allowedChars[random.Next(allowedChars.Length)];

        return new string(stringChars);
    }

    public static void EnumerablePrinter(IEnumerable enumerable)
    {
        Console.WriteLine("Enumerable Printer:");
        foreach (object? item in enumerable) Console.WriteLine(item);
    }
}