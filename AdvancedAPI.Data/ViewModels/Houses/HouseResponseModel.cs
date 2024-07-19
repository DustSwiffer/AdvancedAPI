using Newtonsoft.Json;

namespace AdvancedAPI.Data.ViewModels.Houses;

/// <summary>
/// House response model.
/// </summary>
[JsonObject]
public class HouseResponseModel
{
    /// <summary>
    /// Name of the street where the house is located.
    /// </summary>
    [JsonProperty("street name")]
    public string StreetName { get; set; } = string.Empty;
}
