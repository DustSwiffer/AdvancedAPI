using AdvancedAPI.BaseControllers;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers;

/// <summary>
/// News article endpoint without authorization.
/// </summary>
public class NewsArticleController : BaseController
{
    private readonly INewsArticleService _newsArticleService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public NewsArticleController(INewsArticleService newsArticleService)
    {
        _newsArticleService = newsArticleService;
    }

    /// <summary>
    /// Get list of news articles.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        List<NewsArticleResponseModel> newsArticles = await _newsArticleService.GetList();
        return Ok(newsArticles);
    }
}
