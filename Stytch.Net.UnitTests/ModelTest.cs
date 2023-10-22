using Newtonsoft.Json;
using Stytch.Net.Common.Models;
using Stytch.Net.UnitTests.Resources;

namespace Stytch.Net.UnitTests;

public class ModelTest
{
    [Test]
    public void OperandFilterValueTest()
    {
        Operand.UserIdValue operand = new()
        {
            FilterValue = new[] {"nameId1", "nameId2"}
        };

        string parameters = JsonConvert.SerializeObject(operand);
        const string expected = "{\"filter_name\":\"user_id\",\"filter_value\":[\"nameId1\",\"nameId2\"]}";
        Assert.That(parameters, Is.EqualTo(expected));
    }

    [Test]
    public void StatusEnumTest()
    {
        Operand.Status operand = new()
        {
            FilterValue = StatusEnum.Active
        };

        string parameters = JsonConvert.SerializeObject(operand);
        Assert.That(parameters, Is.EqualTo("{\"filter_name\":\"status\",\"filter_value\":\"active\"}"));
    }

    [Test]
    public void PhoneNumberFormatTest()
    {
        PhoneTestRecord phoneTest = new();

        Assert.DoesNotThrow(() => { phoneTest.PhoneNumberValue = phoneTest.goodNumber; });
        Assert.DoesNotThrow(() => { phoneTest.PhoneNumberValue = phoneTest.incorrectFormat; });
        Assert.Throws<ArgumentException>(() => { phoneTest.PhoneNumberValue = phoneTest.badNumber; });
    }
}