using Newtonsoft.Json;

namespace Stytch.Net.Common.Models;

public record CryptoWallet
{
    [JsonProperty("crypto_wallet_id")] public string? CryptoWalletId { get; set; }

    [JsonProperty("crypto_wallet_address")]
    public string? CryptoWalletAddress { get; set; }

    [JsonProperty("crypto_wallet_type")] public string? CryptoWalletType { get; set; }
    [JsonProperty("verified")] public bool Verified { get; set; }
}