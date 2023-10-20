using Stytch.Net.Models;

namespace Stytch.Net.Common;

public record StytchResult<T> where T : IStytchResponse
{
    public T? Success { get; set; }
    public Error? Error { get; set; }
}