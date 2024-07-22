using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data.Models;

/// <summary>
/// Extension on <see cref="IdentityUser"/>.
/// </summary>
public class User : IdentityUser
{
    /// <summary>
    /// Display name which will be shown to the public.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Date of birth used for validation etc.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gender id.
    /// </summary>
    public int GenderId { get; set; }

    /// <summary>
    /// Gender object.
    /// </summary>
    public Gender Gender { get; set; }
}
