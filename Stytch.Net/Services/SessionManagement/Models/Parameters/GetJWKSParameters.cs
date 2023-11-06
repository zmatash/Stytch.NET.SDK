using Newtonsoft.Json;

namespace Stytch.Net.Services.SessionManagement.Models.Parameters;

public class GetJWKSParameters
{
    [JsonProperty("project_id")] public string ProjectId { get; set; }
}