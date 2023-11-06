using Stytch.Net.Common.Types;
using Stytch.Net.Services.OAuth.Models.Parameters;
using Stytch.Net.Services.OAuth.Models.Responses;

namespace Stytch.Net.Services.OAuth;

public interface IStytchOAuthService
{
    Task<Result<AttachResponse>> Attach(AttachParameters parameters);
    Task<Result<AuthFlowResponse>> Google(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Amazon(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Apple(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Bitbucket(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Coinbase(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Discord(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Facebook(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Figma(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> GitHub(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> GitLab(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> LinkedIn(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Microsoft(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Salesforce(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Slack(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Snapchat(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> TikTok(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Twitch(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Twitter(AuthFlowParameters parameters);
    Task<Result<AuthFlowResponse>> Yahoo(AuthFlowParameters parameters);
    Task<Result<AuthenticateResponse>> Authenticate(AuthenticateParameters parameters);
}