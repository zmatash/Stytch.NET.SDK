using Stytch.Net.Common.PropertyBaseClasses;

namespace Stytch.Net.UnitTests.Resources;

public record PhoneTestRecord : PhoneNumberProperty
{
    public string badNumber = "+a2234";
    public string goodNumber = "+10000000000";
    public string incorrectFormat = "10000000000 ";
}