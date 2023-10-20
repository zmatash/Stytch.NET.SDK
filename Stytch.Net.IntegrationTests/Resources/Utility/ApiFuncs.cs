using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stytch.Net.IntegrationTests.Resources.Utility;

public class ApiFuncs
{
    private readonly HttpClient _httpClient;
    private readonly string _projectId;
    private readonly string _secret;

    public ApiFuncs(string projectId, string secret, HttpClient httpClient)
    {
        _projectId = projectId;
        _secret = secret;
        _httpClient = httpClient;
    }


    public async Task DeleteAllIds()
    {
        HttpRequestMessage request = new(HttpMethod.Post, "https://test.stytch.com/v1/users/search");

        string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_projectId}:{_secret}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);

        request.Content = new StringContent("", Encoding.UTF8, "application/json");

        _httpClient.Timeout = TimeSpan.FromSeconds(10); // Set timeout

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
            newRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);
            tasks.Add(_httpClient.SendAsync(newRequest));
        }

        await Task.WhenAll(tasks);
    }
}