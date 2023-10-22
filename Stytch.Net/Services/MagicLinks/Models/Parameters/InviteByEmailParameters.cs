using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stytch.Net.Common.Models;
using Stytch.Net.Common.Types.Enums;

namespace Stytch.Net.Services.MagicLinks.Models.Parameters;

public record InviteByEmailParameters
{
    [JsonProperty("email")] public string Email { get; set; } = null!;

    [JsonProperty("invite_magic_link_url")]
    public string? InviteMagicLinkUrl { get; set; }

    [JsonProperty("invite_expiration_minutes")]
    public int InviteExpirationMinutes { get; set; } = 60;

    [JsonProperty("invite_template_id")] public string? InviteTemplateId { get; set; }

    [JsonProperty("name")] public Name? Name { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("locale")]
    public LanguageTag Locale { get; set; } = LanguageTag.En;

    [JsonProperty("attributes")] public Attributes? Attributes { get; set; }
}