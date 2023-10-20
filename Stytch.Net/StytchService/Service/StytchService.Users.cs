using Microsoft.Extensions.Logging;
using Stytch.Net.Common;
using Stytch.Net.Common.Utility;
using Stytch.Net.Models;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService
{
    /// <summary>
    ///     Create user asynchronously.
    /// </summary>
    /// <param name="newUserParams">Parameters for creating a user.</param>
    /// <returns>StytchResult containing either the payload or an error object.</returns>
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

    /// <summary>
    ///     Search for users asynchronously.
    /// </summary>
    /// <param name="newSearchUsersParams">Parameters for searching users.</param>
    /// <returns>StytchResult containing either the payload or an error object.</returns>
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

    /// <summary>
    ///     Search for users and paginate results asynchronously.
    /// </summary>
    /// <param name="newSearchUsersParams">Parameters for searching users.</param>
    /// <returns>
    ///     List of StytchResult objects containing either the payload or an error object for each
    ///     page.
    /// </returns>
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

    /// <summary>
    ///     Retrieve user information asynchronously.
    /// </summary>
    /// <param name="userId">UserId of the user to retrieve.</param>
    /// <returns>StytchResult containing either the payload or an error object.</returns>
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

    /// <summary>
    ///     Update a users information.
    ///     Note: Cannot be used to update phone/email, authentication needed with /send.
    /// </summary>
    /// <param name="parameters">Parameters object for request body.</param>
    /// <param name="userId">UserId of the user to update.</param>
    /// <returns>StytchResult containing either the payload or an error object.</returns>
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

    /// <summary>
    ///     Execute API action asynchronously.
    /// </summary>
    /// <param name="method">HttpMethod to use.</param>
    /// <param name="parameters">Parameters object for request body.</param>
    /// <param name="url">API endpoint url.</param>
    /// <returns>StytchResult containing either the payload or an error object.</returns>
    private async Task<StytchResult<T>> ExecuteAsync<T, TU>(HttpMethod method, TU parameters, string url) where T :
        class, IStytchResponse
    {
        HttpRequestMessage request = ApiUtils.CreateRequest(method, url, parameters, Config);
        HttpResponseMessage response = await HttpClient.SendAsync(request).ConfigureAwait(false);
        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return ApiUtils.CreateStytchResult<T>(response, json);
    }


    /// <summary>
    ///     Handle exceptions and return a StytchResult object with error information.
    /// </summary>
    /// <param name="ex">Exception to handle.</param>
    /// <returns>StytchResult containing an error object.</returns>
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