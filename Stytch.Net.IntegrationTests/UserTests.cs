using System.Data;
using Stytch.Net.Common.Models;
using Stytch.Net.Common.Types;
using Stytch.Net.IntegrationTests.Resources;
using Stytch.Net.IntegrationTests.Resources.Data;
using Stytch.Net.Services.Users.Models.Parameters;
using Stytch.Net.Services.Users.Models.Responses;

namespace Stytch.Net.IntegrationTests;

[TestFixture]
public class UserTests : BaseTest
{
    private TestUser testUder { get; set; }

    [Test]
    [Order(1)]
    public async Task TestCreateUser()
    {
        Result<CreateResponse> result = await StytchUserService.CreateAsync(new CreateParameters
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
    [Order(2)]
    public async Task TestSearchUsersByUserId()
    {
        if (TestUser.UserId == null)
            throw new NoNullAllowedException(
                "TestUser does not have ID assigned, something went wrong with TestCreateUser.");

        Result<SearchResponse> result = await StytchUserService.SearchAsync(new SearchParameters
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

    [Test]
    [Order(3)]
    public async Task TestSearchUsersPaginated()
    {
        await StytchUserService.CreateAsync(new CreateParameters {Email = TestUser2.Email});
        List<Result<SearchResponse>> result = await StytchUserService.SearchPaginatedAsync(
            new SearchParameters
            {
                Limit = 1
            });

        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    [Order(4)]
    public async Task TestGetUser()
    {
        Result<GetResponse> result = await StytchUserService.GetAsync(TestUser.UserId!);
        Assert.That(result.Payload?.UserId, Is.EqualTo(TestUser.UserId));
    }

    [Test]
    [Order(5)]
    public async Task TestUpdateUser()
    {
        UpdateParameters param = new()
        {
            Name = new Name
            {
                FirstName = "John",
                MiddleName = "Henry",
                LastName = "Smith"
            }
        };
        Result<UpdateResponse> result = await StytchUserService.UpdateAsync(param, TestUser.UserId);

        Name? newName = result.Payload?.User?.Name;

        Assert.That(newName?.FirstName, Is.EqualTo("John"));
        Assert.That(newName?.MiddleName, Is.EqualTo("Henry"));
        Assert.That(newName?.LastName, Is.EqualTo("Smith"));
    }

    [Test]
    [Order(6)]
    public async Task TestExchangePrimaryFactor()
    {
        const string newEmail = "HueHue@gmail.com";
        ExchangePrimaryFactorParameters param = new()
        {
            EmailAddress = newEmail
        };
        Result<ExchangePrimaryFactorResponse> result =
            await StytchUserService.ExchangePrimaryFactorAsync(param, TestUser.UserId);

        Assert.That(result.Payload?.User?.Emails?[0].EmailValue, Is.EqualTo(newEmail));
        TestUser.Email = newEmail;
    }

    [Test]
    [Order(7)]
    public async Task TestDeleteUser()
    {
        Result<DeleteResponse> result = await StytchUserService.DeleteAsync(TestUser.UserId);
        Assert.That(result.StatusCode, Is.EqualTo(200));
    }

    [Test]
    [Order(8)]
    public async Task TestDeleteUserEmail()
    {
        Result<CreateResponse> userResult = await StytchUserService.CreateAsync(new CreateParameters
        {
            Email = "DeleteEmail@gmail.com"
        });

        string? id = userResult.Payload?.EmailId;

        Result<DeleteInfoResponse> result = await StytchUserService.DeleteEmail(id);
        Assert.That(result.ApiErrorInfo?.ErrorType, Is.EqualTo("cannot_delete_last_primary_factor"));
    }

    [Test]
    [Order(9)]
    public async Task TestDeleteUserPhone()
    {
        Result<CreateResponse> userResult = await StytchUserService.CreateAsync(new CreateParameters
        {
            PhoneNumberValue = "+10000000000"
        });

        string? id = userResult.Payload?.PhoneId;

        Result<DeleteInfoResponse> result = await StytchUserService.DeletePhoneNumber(id);
        Assert.That(result.ApiErrorInfo, Is.Not.EqualTo(null));
        Assert.That(result.ApiErrorInfo?.ErrorType, Is.EqualTo("cannot_delete_last_primary_factor"));
    }
}