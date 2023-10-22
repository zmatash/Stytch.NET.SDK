using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stytch.Net.Common.Models;
using Stytch.Net.Common.Types.Enums;

namespace Stytch.Net.Services.MagicLinks.Models.Parameters;

public record SendMagicLinkEmailParameters
{
    [JsonProperty("email")] public string Email { get; set; } = null!;
    [JsonProperty("login_magic_link_url")] public string? LoginMagicLinkUrl { get; set; }

    [JsonProperty("login_expiration_minutes")]
    public int LoginExpirationMinutes { get; set; } = 60;

    [JsonProperty("login_template_id")] public string? LoginTemplateId { get; set; }
    [JsonProperty("signup_template_id")] public string? SignupTemplateId { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("locale")]
    public LanguageTag Locale { get; set; } = LanguageTag.En;

    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }
    [JsonProperty("code_challenge")] public string? CodeChallenge { get; set; }
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("session_token")] public string? SessionToken { get; set; }
    [JsonProperty("session_jwt")] public string? SessionJwt { get; set; }
}