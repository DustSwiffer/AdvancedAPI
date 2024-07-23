namespace AdvancedAPI.Data.Models;

/// <summary>
/// Last seen state of the user.
/// </summary>
public class LastSeen
{
    /// <summary>
    /// Id of the LastSeen object.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// identifier of the user.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// User object.
    /// </summary>
    public User User;

    /// <summary>
    /// DateTime when user was last seen.
    /// </summary>
    public DateTime DateTime { get; set; }
}
