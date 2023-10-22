using Stytch.Net.Common.Models;
using Stytch.Net.Services;

namespace Stytch.Net.Common.Types;

public record Result<T> : BaseResult where T : IStytchResponse
{
    public T? Payload { get; set; }
    public ApiErrorInfo? ApiErrorInfo { get; set; }
}