using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stytch.Net.Common.Types;
using Stytch.Net.Services.Users.Models.Parameters;
using Stytch.Net.Services.Users.Models.Responses;

namespace Stytch.Net.Services.Users;

public class StytchUserService : BaseStytchService, IStytchUserService
{
    private const string Endpoint = "https://test.stytch.com/v1/users";

    public StytchUserService(IHttpClientFactory httpClientFactory, IOptions<StytchConfiguration> options,
        ILogger<StytchUserService> logger) : base(httpClientFactory, options, logger)
    {
    }

    public async Task<Result<CreateResponse>> CreateAsync(CreateParameters bodyParams)
    {
        try
        {
            return await ExecuteAsync<CreateResponse, CreateParameters>(HttpMethod.Post, bodyParams,
                Endpoint);
        }
        catch (Exception ex)
        {
            return HandleException<CreateResponse>(ex);
        }
    }


    public async Task<Result<SearchResponse>> SearchAsync(SearchParameters bodyParams)
    {
        try
        {
            return await ExecuteAsync<SearchResponse, SearchParameters>(HttpMethod.Post, bodyParams,
                $"{Endpoint}/search");
        }
        catch (Exception ex)
        {
            return HandleException<SearchResponse>(ex);
        }
    }


    public async Task<List<Result<SearchResponse>>> SearchPaginatedAsync(SearchParameters bodyParams)
    {
        List<Result<SearchResponse>> pages = new();
        Result<SearchResponse> page = await SearchAsync(bodyParams).ConfigureAwait(false);
        pages.Add(page);
        string? nextCursor = page.Payload?.ResultsMetaData.NextCursor;

        do
        {
            bodyParams.Cursor = nextCursor;
            page = await SearchAsync(bodyParams).ConfigureAwait(false);
            nextCursor = page.Payload?.ResultsMetaData.NextCursor;
            pages.Add(page);
        } while (!string.IsNullOrEmpty(nextCursor));

        return pages;
    }


    public async Task<Result<GetResponse>> GetAsync(string userId)
    {
        try
        {
            return await ExecuteAsync<GetResponse, string>(HttpMethod.Get, null, $"{Endpoint}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<GetResponse>(ex);
        }
    }


    public async Task<Result<UpdateResponse>> UpdateAsync(UpdateParameters bodyParams, string? userId)
    {
        try
        {
            return await ExecuteAsync<UpdateResponse, UpdateParameters>(HttpMethod.Put, bodyParams,
                $"{Endpoint}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<UpdateResponse>(ex);
        }
    }


    public async Task<Result<ExchangePrimaryFactorResponse>> ExchangePrimaryFactorAsync(
        ExchangePrimaryFactorParameters bodyParams, string? userId)
    {
        try
        {
            return await ExecuteAsync<ExchangePrimaryFactorResponse, ExchangePrimaryFactorParameters>(HttpMethod.Put,
                bodyParams,
                $"{Endpoint}/{userId}/exchange_primary_factor");
        }
        catch (Exception ex)
        {
            return HandleException<ExchangePrimaryFactorResponse>(ex);
        }
    }

    public async Task<Result<DeleteResponse>> DeleteAsync(string? userId)
    {
        try
        {
            return await ExecuteAsync<DeleteResponse, string>(HttpMethod.Delete, null, $"{Endpoint}/{userId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeleteEmail(string? emailId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/emails/{emailId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeletePhoneNumber(string? phoneId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/phone_numbers/{phoneId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeleteWebAuthnRegistration(string? webAuthnId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/webauthn_registrations/{webAuthnId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeleteTotp(string? totpId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/totps/{totpId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeleteCryptoWallet(string? cryptoWalletId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/crypto_wallets/{cryptoWalletId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeletePassword(string? passwordId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/passwords/{passwordId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }

    public async Task<Result<DeleteInfoResponse>> DeleteOAuthRegistration(string? oauthId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/oauth/{oauthId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }


    public async Task<Result<DeleteInfoResponse>> DeleteBiometricRegistration(string? biometricRegistrationId)
    {
        try
        {
            return await ExecuteAsync<DeleteInfoResponse, string>(HttpMethod.Delete, null,
                $"{Endpoint}/biometric_registrations/{biometricRegistrationId}");
        }
        catch (Exception ex)
        {
            return HandleException<DeleteInfoResponse>(ex);
        }
    }
}