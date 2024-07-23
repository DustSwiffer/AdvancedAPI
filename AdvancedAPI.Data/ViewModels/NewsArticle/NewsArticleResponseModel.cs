// <copyright file="NewsArticleResponseModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AdvancedAPI.Data.ViewModels.NewsArticle;

/// <summary>
/// Response model for news article.
/// </summary>
public class NewsArticleResponseModel
{
    /// <summary>
    /// identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Header text.
    /// </summary>
    public string HeaderText { get; set; }

    /// <summary>
    /// Content in HTML format.
    /// </summary>
    public string ContentHtml { get; set; }

    /// <summary>
    /// Release date of the article.
    /// </summary>
    public DateTime ReleaseDate { get; set; }
}
