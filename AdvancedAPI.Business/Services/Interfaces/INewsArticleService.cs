using AdvancedAPI.Data.ViewModels.NewsArticle;

namespace Business.Services.Interfaces;

/// <summary>
/// news article service.
/// </summary>
public interface INewsArticleService
{
    /// <summary>
    /// Inserts a new news article into the database.
    /// </summary>
    public Task<bool> CreateNewsArticle(NewsArticleRequestModel requestModel);

    /// <summary>
    /// Deletes the news article from the database.
    /// </summary>
    public Task<bool> DeleteNewsArticle(int id);
}
