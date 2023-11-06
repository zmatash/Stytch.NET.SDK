using Stytch.Net.Common.Types;
using Stytch.Net.IntegrationTests.Resources;
using Stytch.Net.Services.MagicLinks.Models.Parameters;
using Stytch.Net.Services.MagicLinks.Models.Responses;

namespace Stytch.Net.IntegrationTests;

public class MagicLinkTests : BaseTest
{
    [Test]
    public async Task MagicLinkEmailTest()
    {
        SendEmailParameters body = new() {Email = SandboxEmail};

        Result<SendEmailResponse> result = await MagicLinkService.SendEmailAsync(body);
        Assert.That(result.IsSuccessStatusCode);
    }

    [Test]
    public async Task MagicLinkLoginOrCreateUserTest()
    {
        LoginOrCreateUserParameters body = new() {Email = SandboxEmail};

        Result<LoginOrCreateUserResponse> result = await MagicLinkService.LoginOrCreateUserAsync(body);
        Assert.That(result.IsSuccessStatusCode);
    }

    [Test]
    public async Task MagicLinkInviteTest()
    {
        InviteParameters body = new() {Email = SandboxEmail};

        Result<InviteResponse> result = await MagicLinkService.InviteAsync(body);
        Assert.That(result.IsSuccessStatusCode);
    }
}