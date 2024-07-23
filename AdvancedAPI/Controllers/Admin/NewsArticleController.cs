using AdvancedAPI.BaseControllers;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAPI.Controllers.Admin;

/// <summary>
/// News article admin controller.
/// </summary>
public class NewsArticleController : AdminBaseController
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
    /// Creates a news article
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewsArticleRequestModel requestModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequestResult(null);
        }

        if (await _newsArticleService.CreateNewsArticle(requestModel))
        {
            return Ok("News article got created");
        }

        return Problem("could not create the news article");
    }

    /// <summary>
    /// Deletes the news article.
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> Create([FromBody] int id)
    {
        if (id == 0)
        {
            return BadRequestResult("No Id was filled in!");
        }

        if (await _newsArticleService.DeleteNewsArticle(id))
        {
            return Ok("The news article got deleted");
        }

        return Problem("Could not delete the given new article");
    }
}
