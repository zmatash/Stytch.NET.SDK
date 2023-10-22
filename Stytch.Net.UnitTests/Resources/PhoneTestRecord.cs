using Stytch.Net.Common2.Models.Properties;

namespace Stytch.Net.UnitTests.Resources;

public record PhoneTestRecord : PhoneNumber
{
    public string badNumber = "+a2234";
    public string goodNumber = "+10000000000";
    public string incorrectFormat = "10000000000 ";
}