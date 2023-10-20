using Newtonsoft.Json;
using Stytch.Net.Common;
using Stytch.Net.Models;

namespace Stytch.Net.StytchService.Models.Responses;

public record UpdateUserResponse : IStytchResponse
{
    [JsonProperty("user_id")] public string? UserId { get; set; }
    [JsonProperty("user")] public User? User { get; set; }
    [JsonProperty("emails")] public Email[]? Emails { get; set; }
    [JsonProperty("phone_numbers")] public PhoneNumber[]? PhoneNumbers { get; set; }
    [JsonProperty("crypto_wallets")] public CryptoWallet[]? CryptoWallets { get; set; }
}