using Microsoft.Extensions.Logging;
using Stytch.Net.Common;
using Stytch.Net.Common.Utility;
using Stytch.Net.Models;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public partial class StytchService
{
    public async Task<StytchResult<CreateUserResponse>> CreateUser(CreateUserParameters newUserParams)
    {
        try
        {
            HttpRequestMessage request = ApiUtils.CreateRequest(HttpMethod.Post, BaseApi, newUserParams, Config);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            StytchResult<CreateUserResponse> result = ApiUtils.CreateStytchResult<CreateUserResponse>(response, json);
            return result;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, "An error occurred while creating a user: {Ex}", ex);
            StytchResult<CreateUserResponse> result = new()
            {
                StatusCode = 500,
                ApiErrorInfo = new ApiErrorInfo
                {
                    ErrorMessage = $"Internal Server ApiErrorInfo: {ex}"
                }
            };
            return result;
        }
    }

    public async Task<StytchResult<SearchUsersResponse>> SearchUsers(SearchUsersParameters newSearchUsersParams)
    {
        try
        {
            HttpRequestMessage request =
                ApiUtils.CreateRequest(HttpMethod.Post, BaseApi + "/search", newSearchUsersParams, Config);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            StytchResult<SearchUsersResponse> result = ApiUtils.CreateStytchResult<SearchUsersResponse>(response, json);
            return result;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, "An error occurred while creating a user: {Ex}", ex);
            StytchResult<SearchUsersResponse> result = new()
            {
                StatusCode = 500,
                ApiErrorInfo = new ApiErrorInfo
                {
                    ErrorMessage = $"Internal Server ApiErrorInfo: {ex}"
                }
            };
            return result;
        }
    }

    public async Task<List<StytchResult<SearchUsersResponse>>> SearchUsersPaginated(
        SearchUsersParameters newSearchUsersParams)
    {
        List<StytchResult<SearchUsersResponse>> pages = new();
        string? nextCursor;

        do
        {
            StytchResult<SearchUsersResponse> page = await SearchUsers(newSearchUsersParams);
            nextCursor = page.Payload?.ResultsMetaData.NextCursor;
            pages.Add(page);
        } while (!string.IsNullOrEmpty(nextCursor));

        return pages;
    }
}