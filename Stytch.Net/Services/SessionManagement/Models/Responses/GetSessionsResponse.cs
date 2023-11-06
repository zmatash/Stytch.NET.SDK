using Newtonsoft.Json;
using Stytch.Net.Common.Models;

namespace Stytch.Net.Services.SessionManagement.Models.Responses;

public class GetSessionsResponse : IStytchResponse
{
    [JsonProperty("sessions")] public UserSession[] Sessions { get; set; }
}