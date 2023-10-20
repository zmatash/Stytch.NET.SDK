using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public interface IStytchService
{
    Task<StytchResult<CreateUserResponse>> CreateUserAsync(CreateUserParameters parameters);
    Task<StytchResult<SearchUsersResponse>> SearchUsersAsync(SearchUsersParameters parameters);
    Task<List<StytchResult<SearchUsersResponse>>> SearchUsersPaginatedAsync(SearchUsersParameters parameters);
    Task<StytchResult<GetUserResponse>> GetUserAsync(string parameters);
    Task<StytchResult<UpdateUserResponse>> UpdateUserAsync(UpdateUserParameters parameters, string? userId);
}