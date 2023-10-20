using System.Data;
using Stytch.Net.Common;
using Stytch.Net.IntegrationTests.Resources;
using Stytch.Net.IntegrationTests.Resources.Data;
using Stytch.Net.Models;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.IntegrationTests;

[TestFixture]
public class UserTests : BaseTest
{
    private TestUser testUder { get; set; }

    [Test]
    public async Task TestCreateUser()
    {
        StytchResult<CreateUserResponse> result = await StytchService.CreateUser(new CreateUserParameters
        {
            Email = TestUser.Email,
            Name = new Name
            {
                FirstName = TestUser.FirstName,
                MiddleName = TestUser.MiddleName,
                LastName = TestUser.LastName
            }
        });

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Payload, Is.Not.Null);
        Assert.That(result.Payload?.User, Is.Not.Null);

        User? user = result.Payload?.User;

        // Name synced with auth server
        Assert.That(user?.Name?.FirstName, Is.EqualTo(TestUser.FirstName));
        Assert.That(user?.Name?.MiddleName, Is.EqualTo(TestUser.MiddleName));
        Assert.That(user?.Name?.LastName, Is.EqualTo(TestUser.LastName));

        // Email synced with auth server
        Assert.That(user?.Emails[0].EmailValue, Is.EqualTo(TestUser.Email));

        // User_id returned
        Assert.That(!string.IsNullOrEmpty(user?.UserId));

        // Assign user ID to set state for later tests.
        TestUser.UserId = user!.UserId;
    }

    [Test]
    public async Task TestSearchUsersByUserId()
    {
        if (TestUser.UserId == null)
            throw new NoNullAllowedException(
                "TestUser does not have ID assigned, something went wrong with TestCreateUser.");

        StytchResult<SearchUsersResponse> result = await StytchService.SearchUsers(new SearchUsersParameters
            {
                Query = new Query
                {
                    Operands = new IOperandValue[]
                    {
                        new Operand.UserIdValue {FilterValue = new[] {TestUser.UserId}}
                    }
                }
            }
        );

        Assert.That(result.Payload?.Results, Is.Not.EqualTo(null));

        User[] users = result.Payload?.Results!;

        // Name correctly retrieved
        Assert.That(users, Has.Length.EqualTo(1));
        Assert.That(users[0].Name?.FirstName, Is.EqualTo(TestUser.FirstName));
        Assert.That(users[0].Name?.MiddleName, Is.EqualTo(TestUser.MiddleName));
        Assert.That(users[0].Name?.LastName, Is.EqualTo(TestUser.LastName));

        // Email correctly retrieved
        Assert.That(users[0].Emails, Has.Length.EqualTo(1));
        Assert.That(users[0].Emails[0].EmailValue, Is.EqualTo(TestUser.Email));
    }
}