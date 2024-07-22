using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AdvancedAPI.Data.ViewModels.NewsArticle;

/// <summary>
/// Request model to create or update a news article.
/// </summary>
[JsonObject]
public class NewsArticleRequestModel
{
    /// <summary>
    /// Identifier of news article (if editted)
    /// </summary>
    public int id { get; set; }

    /// <summary>
    /// Header text.
    /// </summary>
    [Required]
    [MaxLength(75)]
    public string HeaderText { get; set; }

    /// <summary>
    /// Content written in HTML.
    /// </summary>
    [Required]
    public string ContentHtml { get; set; }
}
