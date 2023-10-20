using Newtonsoft.Json;
using Stytch.Net.Models;

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
    }
}