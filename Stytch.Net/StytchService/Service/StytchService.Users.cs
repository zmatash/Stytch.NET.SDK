using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService
{
    public async Task<StytchResult<CreateUserResponse>> CreateUserAsync(CreateUserParameters newUserParams)
    {
        try
        {
            return await ExecuteAsync<CreateUserResponse, CreateUserParameters>(HttpMethod.Post, newUserParams,
                UsersApi);
        }
        catch (Exception ex)
        {
            return HandleException<CreateUserResponse>(ex);
        }
    }


    public async Task<StytchResult<SearchUsersResponse>> SearchUsersAsync(SearchUsersParameters newSearchUsersParams)
    {
        try
        {
            return await ExecuteAsync<SearchUsersResponse, SearchUsersParameters>(HttpMethod.Post, newSearchUsersParams,
                $"{UsersApi}/search");
        }
        catch (Exception ex)
        {
            return HandleException<SearchUsersResponse>(ex);
        }
    }


    public async Task<List<StytchResult<SearchUsersResponse>>> SearchUsersPaginatedAsync(
        SearchUsersParameters newSearchUsersParams)
    {
        List<StytchResult<SearchUsersResponse>> pages = new();
        StytchResult<SearchUsersResponse> page = await SearchUsersAsync(newSearchUsersParams).ConfigureAwait(false);
        pages.Add(page);
        string? nextCursor = page.Payload?.ResultsMetaData.NextCursor;

        do
        {
            newSearchUsersParams.Cursor = nextCursor;
            page = await SearchUsersAsync(newSearchUsersParams).ConfigureAwait(false);
            nextCursor = page.Payload?.ResultsMetaData.NextCursor;
            pages.Add(page);
        } while (!string.IsNullOrEmpty(nextCursor));

        return pages;
    }


    public async Task<StytchResult<GetUserResponse>> GetUserAsync(string userId)
    {
        try
        {
            return await ExecuteAsync<GetUserResponse, string>(HttpMethod.Get, "", $"{UsersApi}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<GetUserResponse>(ex);
        }
    }


    public async Task<StytchResult<UpdateUserResponse>> UpdateUserAsync(UpdateUserParameters parameters, string? userId)
    {
        try
        {
            return await ExecuteAsync<UpdateUserResponse, UpdateUserParameters>(HttpMethod.Put, parameters,
                $"{UsersApi}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<UpdateUserResponse>(ex);
        }
    }


    public async Task<StytchResult<ExchangePrimaryFactorResponse>> ExchangePrimaryFactorAsync(
        ExchangePrimaryFactorParameters parameters, string? userId)
    {
        try
        {
            return await ExecuteAsync<ExchangePrimaryFactorResponse, ExchangePrimaryFactorParameters>(HttpMethod.Put,
                parameters,
                $"{UsersApi}/{userId}/exchange_primary_factor");
        }
        catch (Exception ex)
        {
            return HandleException<ExchangePrimaryFactorResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteUserResponse>> DeleteUserAsync(string? userId)
    {
        try
        {
            return await ExecuteAsync<DeleteUserResponse, string>(HttpMethod.Delete, "", $"{UsersApi}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteUserResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserEmail(string? emailId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/emails/{emailId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserPhoneNumber(string? phoneId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/phone_numbers/{phoneId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserWebAuthnRegistration(string? webAuthnId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/webauthn_registrations/{webAuthnId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserTotp(string? totpId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/totps/{totpId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserCryptoWallet(string? cryptoWalletId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/crypto_wallets/{cryptoWalletId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserPassword(string? passwordId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/passwords/{passwordId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserOAuthRegistration(string? oauthId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/oauth/{oauthId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }


    public async Task<StytchResult<DeleteInfoResponse>> DeleteUserBiometricRegistration(string? biometricRegistrationId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, "",
                $"{UsersApi}/biometric_registrations/{biometricRegistrationId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }
}