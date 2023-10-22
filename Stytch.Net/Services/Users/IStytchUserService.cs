using Stytch.Net.Common.Types;
using Stytch.Net.Services.Users.Models.Parameters;
using Stytch.Net.Services.Users.Models.Responses;

namespace Stytch.Net.Services.Users;

public interface IStytchUserService
{
    Task<Result<CreateResponse>> CreateAsync(CreateParameters parameters);
    Task<Result<SearchResponse>> SearchAsync(SearchParameters parameters);
    Task<List<Result<SearchResponse>>> SearchPaginatedAsync(SearchParameters parameters);
    Task<Result<GetResponse>> GetAsync(string userId);
    Task<Result<UpdateResponse>> UpdateAsync(UpdateParameters parameters, string userId);

    Task<Result<ExchangePrimaryFactorResponse>> ExchangePrimaryFactorAsync(
        ExchangePrimaryFactorParameters parameters,
        string? userId);

    Task<Result<DeleteResponse>> DeleteAsync(string userId);

    Task<Result<DeleteInfoResponse>> DeleteEmail(string emailId);
    Task<Result<DeleteInfoResponse>> DeletePhoneNumber(string? phoneId);
    Task<Result<DeleteInfoResponse>> DeleteWebAuthnRegistration(string? webAuthnId);

    Task<Result<DeleteInfoResponse>> DeleteBiometricRegistration(
        string? biometricRegistrationId);

    Task<Result<DeleteInfoResponse>> DeleteTotp(string? totpId);
    Task<Result<DeleteInfoResponse>> DeleteCryptoWallet(string? cryptoWalletId);
    Task<Result<DeleteInfoResponse>> DeletePassword(string? passwordId);
    Task<Result<DeleteInfoResponse>> DeleteOAuthRegistration(string? oauthId);
}