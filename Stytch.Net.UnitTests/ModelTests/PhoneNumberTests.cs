using Stytch.Net.Common.Models;

namespace Stytch.Net.UnitTests;

public class PhoneNumberTests
{
    [Test]
    [TestCase("+100000")]
    public void GoodPhoneNumber(string phoneNumber)
    {
        Assert.DoesNotThrow(() =>
        {
            // ReSharper disable once UnusedVariable
            Phone phone = new() {Number = phoneNumber};
        });
    }

    [Test]
    [TestCase("+100000 234 1")]
    [TestCase("100000 234 1")]
    public void RecoverableFormatPhoneNumber(string phoneNumber)
    {
        Assert.DoesNotThrow(() =>
        {
            // ReSharper disable once UnusedVariable
            Phone phone = new() {Number = phoneNumber};
        });
    }

    [Test]
    [TestCase("+1000002341111111111111111111111111222222222222")]
    [TestCase("100a00 234 1")]
    public void BadPhoneNumber(string phoneNumber)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            // ReSharper disable once UnusedVariable
            Phone phone = new() {Number = phoneNumber};
        });
    }
}