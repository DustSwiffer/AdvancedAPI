using System.ComponentModel.DataAnnotations;

namespace AdvancedAPI.Data.Models;

/// <summary>
/// Gender model.
/// Used as model in case the gender list needs expansion.
/// </summary>
public class Gender
{
    /// <summary>
    /// Identifier of gender.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// name of the gender.
    /// </summary>
    public string Name { get; set; }
}
