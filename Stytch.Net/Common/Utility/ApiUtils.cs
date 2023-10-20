using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        // Status_code and requestId are assigned to root of StytchResult object.
        // Remove from json so they aren't assigned to the error or payload, avoid duplication.
        StytchResult<TSuccess> result = new();
        JObject jsonObj = JObject.Parse(json);
        result.RequestId = (string) jsonObj["request_id"]!;
        result.StatusCode = (int) jsonObj["status_code"]!;
        jsonObj.Remove("status_code");
        jsonObj.Remove("request_id");

        if (response.IsSuccessStatusCode)
        {
            result.Payload = jsonObj.ToObject<TSuccess>();
            return result;
        }

        result.ApiErrorInfo = jsonObj.ToObject<ApiErrorInfo>();
        return result;
    }
}