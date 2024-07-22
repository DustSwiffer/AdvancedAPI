using System.ComponentModel.DataAnnotations;

namespace AdvancedAPI.Data.Models;

/// <summary>
/// News article model.
/// </summary>
public class NewsArticle
{
    /// <summary>
    /// Identifier of the news article.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Header text of the news article.
    /// </summary>
    public string HeaderText { get; set; }

    /// <summary>
    /// Content (html) of the news article.
    /// </summary>
    public string ContentHtml { get; set; }

    /// <summary>
    /// Release date of the news article.
    /// </summary>
    public DateTime ReleaseDate { get; set; }
}
