using Stytch.Net.Common;
using Stytch.Net.StytchService.Models.Parameters;
using Stytch.Net.StytchService.Models.Responses;

namespace Stytch.Net.StytchService.Service;

public interface IStytchService
{
    Task<StytchResult<CreateUserResponse>> CreateUser(CreateUserParameters newUserParams);
    Task<StytchResult<SearchUsersResponse>> SearchUsers(SearchUsersParameters newUserParams);
}