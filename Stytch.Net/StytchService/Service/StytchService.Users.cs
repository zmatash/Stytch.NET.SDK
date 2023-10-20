using Microsoft.Extensions.Logging;
using Stytch.Net.Common;
using Stytch.Net.Common.Utility;
using Stytch.Net.Models;
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
                BaseApi);
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
                $"{BaseApi}/search");
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
            return await ExecuteAsync<GetUserResponse, string>(HttpMethod.Get, "", $"{BaseApi}/{userId}");
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
                $"{BaseApi}/{userId}");
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
                $"{BaseApi}/{userId}/exchange_primary_factor");
        }
        catch (Exception ex)
        {
            return HandleException<ExchangePrimaryFactorResponse>(ex);
        }
    }

    private async Task<StytchResult<T>> ExecuteAsync<T, TU>(HttpMethod method, TU parameters, string url) where T :
        class, IStytchResponse
    {
        HttpRequestMessage request = ApiUtils.CreateRequest(method, url, parameters, Config);
        HttpResponseMessage response = await HttpClient.SendAsync(request).ConfigureAwait(false);
        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return ApiUtils.CreateStytchResult<T>(response, json);
    }

    private StytchResult<T> HandleException<T>(Exception ex) where T : IStytchResponse
    {
        _logger.Log(LogLevel.Error, "Error: {Ex}", ex);
        return new StytchResult<T>
        {
            StatusCode = 500,
            ApiErrorInfo = new ApiErrorInfo
            {
                ErrorMessage = $"Internal Server ApiErrorInfo: {ex}"
            }
        };
    }
}