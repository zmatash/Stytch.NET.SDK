using Stytch.Net.Common.Types;
using Stytch.Net.Services.OAuth.Models.Parameters;
using Stytch.Net.Services.SessionManagement.Models.Parameters;
using Stytch.Net.Services.SessionManagement.Models.Responses;

namespace Stytch.Net.Services.SessionManagement;

public interface IStytchSessionManagementService
{
    Task<Result<GetJWKSResponse>> GetJWKS(GetJWKSParameters parameters);
    Task<Result<GetSessionsResponse>> GetSessions(GetSessionsParameters parameters);
    Task<Result<AuthenticateSessionResponse>> AuthenticateSession(AuthenticateSessionParameters parameters);
    Task<Result<RevokeSessionResponse>> RevokeSession(RevokeSessionParameters parameters);
}