using Newtonsoft.Json;

namespace Stytch.Net.Services.OAuth.Models.Parameters;

public class AuthFlowParameters
{
    [JsonProperty("public_token")] public string PublicToken { get; set; }
    [JsonProperty("login_redirect_url")] public string LoginRedirectUrl { get; set; }
    [JsonProperty("signup_redirect_url")] public string SignupRedirectUrl { get; set; }
    [JsonProperty("custom_scopes")] public string CustomScopes { get; set; }
    [JsonProperty("code_challenge")] public string CodeChallenge { get; set; }
    [JsonProperty("oauth_attach_token")] public string AOuthAttachToken { get; set; }
}