using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public interface IStytchService
{
    Task<StytchResult<CreateUserResponse>> CreateUser(CreateUserParameters parameters);
    Task<StytchResult<SearchUsersResponse>> SearchUsers(SearchUsersParameters parameters);
    Task<List<StytchResult<SearchUsersResponse>>> SearchUsersPaginated(SearchUsersParameters parameters);
    Task<StytchResult<GetUserResponse>> GetUser(string parameters);
    Task<StytchResult<UpdateUserResponse>> UpdateUser(UpdateUserParameters parameters, string? userId);
}