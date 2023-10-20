using Stytch.Net.Models;

namespace Stytch.Net.Common;

public record StytchResult<T> : BaseResult where T : IStytchResponse
{
    public T? Payload { get; set; }
    public ApiErrorInfo? ApiErrorInfo { get; set; }
}