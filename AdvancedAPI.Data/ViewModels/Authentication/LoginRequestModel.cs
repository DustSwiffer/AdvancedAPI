using Newtonsoft.Json;

namespace AdvancedAPI.Data.ViewModels.Authentication;

/// <summary>
/// Request model to login.
/// </summary>
[JsonObject]
public class LoginRequestModel
{
    /// <summary>
    ///  user name.
    /// </summary>
    [JsonProperty("User name")]
    public string Username { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    [JsonProperty("Password")]
    public string Password { get; set; }
}
