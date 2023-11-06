using Newtonsoft.Json;

namespace Stytch.Net.Services.SessionManagement.Models.Parameters;

public class GetSessionsParameters
{
    [JsonProperty("user_id")] public string UserId { get; set; }
}