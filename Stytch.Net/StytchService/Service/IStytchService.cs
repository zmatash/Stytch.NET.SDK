using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public interface IStytchService
{
    Task<StytchResult<CreateUserResponse>> CreateUserAsync(CreateUserParameters parameters);
    Task<StytchResult<SearchUsersResponse>> SearchUsersAsync(SearchUsersParameters parameters);
    Task<List<StytchResult<SearchUsersResponse>>> SearchUsersPaginatedAsync(SearchUsersParameters parameters);
    Task<StytchResult<GetUserResponse>> GetUserAsync(string userId);
    Task<StytchResult<UpdateUserResponse>> UpdateUserAsync(UpdateUserParameters parameters, string userId);

    Task<StytchResult<ExchangePrimaryFactorResponse>> ExchangePrimaryFactorAsync(
        ExchangePrimaryFactorParameters parameters,
        string? userId);

    Task<StytchResult<DeleteUserResponse>> DeleteUserAsync(string userId);

    Task<StytchResult<DeleteInfoResponse>> DeleteUserEmail(string emailId);
    Task<StytchResult<DeleteInfoResponse>> DeleteUserPhoneNumber(string? phoneId);
    Task<StytchResult<DeleteInfoResponse>> DeleteUserWebAuthnRegistration(string? webAuthnId);

    Task<StytchResult<DeleteInfoResponse>> DeleteUserBiometricRegistration(
        string? biometricRegistrationId);

    Task<StytchResult<DeleteInfoResponse>> DeleteUserTotp(string? totpId);
    Task<StytchResult<DeleteInfoResponse>> DeleteUserCryptoWallet(string? cryptoWalletId);
    Task<StytchResult<DeleteInfoResponse>> DeleteUserPassword(string? passwordId);
    Task<StytchResult<DeleteInfoResponse>> DeleteUserOAuthRegistration(string? oauthId);
}