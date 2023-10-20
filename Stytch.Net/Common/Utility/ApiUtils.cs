using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Stytch.Net.Models;

namespace Stytch.Net.Common.Utility;

public static class ApiUtils
{
    public static HttpRequestMessage CreateRequest<T>(HttpMethod method, string url, T body, StytchConfiguration config)
    {
        HttpRequestMessage request = new(method, url);

        string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.ProjectId}:{config.Secret}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);

        string parameters = JsonConvert.SerializeObject(body);
        request.Content = new StringContent(parameters, Encoding.UTF8, "application/json");

        return request;
    }

    public static StytchResult<TSuccess> CreateStytchResult<TSuccess>(HttpResponseMessage response, string json)
        where TSuccess : class, IStytchResponse
    {
        StytchResult<TSuccess> result = new();
        if (response.IsSuccessStatusCode)
        {
            result.Success = JsonConvert.DeserializeObject<TSuccess>(json);
            return result;
        }

        Error errorBody = JsonConvert.DeserializeObject<Error>(json)!;
        result.Error = errorBody;
        return result;
    }
}