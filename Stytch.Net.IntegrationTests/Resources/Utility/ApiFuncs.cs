using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stytch.Net.IntegrationTests.Resources.Utility;

public class ApiFuncs
{
    private readonly string _auth;
    private readonly HttpClient _httpClient;


    public ApiFuncs(string projectId, string secret, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{projectId}:{secret}"));
    }

    public async Task DeleteAllIds()
    {
        HttpRequestMessage request = new(HttpMethod.Post, "https://test.stytch.com/v1/users/search");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _auth);
        request.Content = new StringContent("", Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();
        JObject? jsonDict = JsonConvert.DeserializeObject<JObject>(content);

        List<string> uids = new();

        if (jsonDict == null) throw new NullReferenceException("DeleteAllIds Helper: Json object is null");

        uids.AddRange(jsonDict["results"]!.Select(user => user["user_id"]!.ToString()));

        List<Task> tasks = new();
        foreach (string id in uids)
        {
            string url = $"https://test.stytch.com/v1/users/{id}";
            HttpRequestMessage newRequest = new(HttpMethod.Delete, url);
            newRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", _auth);
            tasks.Add(_httpClient.SendAsync(newRequest));
        }

        await Task.WhenAll(tasks);
    }
}