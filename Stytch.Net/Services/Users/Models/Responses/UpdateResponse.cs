using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.Users.Models.Responses;

public record UpdateResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
    [JsonProperty("emails")] public Email[]? Emails { get; set; }
    [JsonProperty("phone_numbers")] public Phone[]? PhoneNumbers { get; set; }
    [JsonProperty("crypto_wallets")] public CryptoWallet[]? CryptoWallets { get; set; }
}