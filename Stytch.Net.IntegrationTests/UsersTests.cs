using Stytch.Net.Common.Models;
using Stytch.Net.Common.Types;
using Stytch.Net.IntegrationTests.Resources;
using Stytch.Net.IntegrationTests.Resources.Data;
using Stytch.Net.Services.Users.Models.Parameters;
using Stytch.Net.Services.Users.Models.Responses;

namespace Stytch.Net.IntegrationTests;

public class UsersTests : BaseTest
{
    [Test]
    [Order(1)]
    public async Task TestCreateAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        CreateParameters body = new()
        {
            Email = testUser.Email,
            PhoneNumber = testUser.PhoneNumber,
            Name = new Name
            {
                FirstName = testUser.FirstName,
                LastName = testUser.LastName,
                MiddleName = testUser.MiddleName
            }
        };

        Result<CreateResponse> result = await UserService.CreateAsync(body);
        Assert.That(result.IsSuccessStatusCode);

        User createdUser = result.Payload!.User!;
        Assert.That(createdUser.Emails?[0].Address, Is.EqualTo(testUser.Email));
        Assert.That(createdUser.PhoneNumbers?[0].Number, Is.EqualTo(testUser.PhoneNumber));
        Assert.Multiple(() =>
        {
            Assert.That(createdUser.Name?.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(createdUser.Name?.MiddleName, Is.EqualTo(testUser.MiddleName));
            Assert.That(createdUser.Name?.LastName, Is.EqualTo(testUser.LastName));
        });
    }

    [Test]
    public async Task TestSearchAsync()
    {
        List<TestUser> testUsers = UserFactory.CreateMockUsers(2);
        foreach (TestUser user in testUsers) await UserService.CreateAsync(new CreateParameters {Email = user.Email});

        SearchParameters body = new()
        {
            Query = new Query
            {
                Operands = new IOperandValue[]
                {
                    new Operand.EmailAddress {FilterValue = new[] {testUsers[0].Email}}
                }
            }
        };

        Result<SearchResponse> result = await UserService.SearchAsync(body);
        Assert.That(result.IsSuccessStatusCode);

        User[] users = result.Payload!.Results;
        Assert.That(users, Has.Length.EqualTo(1));
    }

    [Test]
    [TestCase(3, 1, 3)]
    [TestCase(3, 2, 2)]
    public async Task TestSearchPaginatedAsync(int userCount, int pageLimit, int expectedPages)

    {
        List<TestUser> testUsers = UserFactory.CreateMockUsers(userCount);
        foreach (TestUser user in testUsers) await UserService.CreateAsync(new CreateParameters {Email = user.Email});

        SearchParameters body = new()
        {
            Limit = pageLimit
        };

        List<Result<SearchResponse>> resultList = await UserService.SearchPaginatedAsync(body);
        foreach (Result<SearchResponse> result in resultList) Assert.That(result.IsSuccessStatusCode);
        Assert.That(resultList, Has.Count.EqualTo(expectedPages));
    }

    [Test]
    public async Task TestGetAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        Result<CreateResponse> userResult =
            await UserService.CreateAsync(new CreateParameters {Email = testUser.Email});

        string? userId = userResult.Payload!.User!.UserId;
        Result<GetResponse> getResult = await UserService.GetAsync(userId!);
        Assert.That(getResult.IsSuccessStatusCode);
        Assert.That(getResult.Payload!.UserId, Is.EqualTo(userId));
    }

    [Test]
    public async Task TestUpdateAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        Result<CreateResponse> userResult =
            await UserService.CreateAsync(new CreateParameters {Email = testUser.Email});

        UpdateParameters body = new()
        {
            Name = new Name
            {
                FirstName = testUser.FirstName,
                MiddleName = testUser.MiddleName,
                LastName = testUser.LastName
            }
        };

        Result<UpdateResponse> result = await UserService.UpdateAsync(body, userResult.Payload!.UserId!);
        Assert.That(result.IsSuccessStatusCode);
        Assert.Multiple(() =>
        {
            Assert.That(result.Payload!.User!.Name!.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.Payload!.User!.Name!.MiddleName, Is.EqualTo(testUser.MiddleName));
            Assert.That(result.Payload!.User!.Name!.LastName, Is.EqualTo(testUser.LastName));
        });
    }

    [Test]
    public async Task DeleteAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        Result<CreateResponse> userResult =
            await UserService.CreateAsync(new CreateParameters {Email = testUser.Email});

        CreateResponse user = userResult.Payload!;

        Result<DeleteResponse> result = await UserService.DeleteAsync(user.UserId!);
        Assert.That(result.IsSuccessStatusCode);
        Assert.That(result.Payload!.UserId, Is.EqualTo(user.UserId));
    }

    [Test]
    public async Task DeleteEmailAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        Result<CreateResponse> userResult =
            await UserService.CreateAsync(new CreateParameters
                {Email = testUser.Email, PhoneNumber = testUser.PhoneNumber});

        Result<DeleteInfoResponse> result = await UserService.DeleteEmail(userResult.Payload!.EmailId!);
        Assert.That(result.IsSuccessStatusCode);

        User user = result.Payload!.User!;
        Assert.That(user.Emails!, Is.Empty);
    }

    [Test]
    public async Task DeletePhoneNumberAsync()
    {
        TestUser testUser = UserFactory.CreateMockUser();
        Result<CreateResponse> userResult =
            await UserService.CreateAsync(new CreateParameters
                {Email = testUser.Email, PhoneNumber = testUser.PhoneNumber});

        Result<DeleteInfoResponse> result = await UserService.DeletePhoneNumber(userResult.Payload!.PhoneId!);

        Assert.That(result.IsSuccessStatusCode);
        User user = result.Payload!.User!;
        Assert.That(user.PhoneNumbers!, Is.Empty);
    }
}