namespace AdvancedAPI.Data.ViewModels.User;

/// <summary>
/// User profike response model.
/// </summary>
public class UserProfileResponseModel
{
    /// <summary>
    /// identifier of the user.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// display name of the user.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Birthday of the user.
    /// </summary>
    public string Birthday { get; set; }

    /// <summary>
    /// Gender of the user.
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Timespan of how long ago the user
    /// </summary>
    public string LastSeen { get; set; }
}
