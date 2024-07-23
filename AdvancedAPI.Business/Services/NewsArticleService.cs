using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using AutoMapper;
using Business.Services.Interfaces;

namespace Business.Services;

/// <inheritdoc />
public class NewsArticleService : INewsArticleService
{
    private readonly ILogger<NewsArticleService> _logger;
    private readonly IMapper _mapper;
    private readonly INewsArticleRepository _newsArticleRepository;

    /// <summary>
    /// Constructor.
    /// </summary>
    public NewsArticleService(ILogger<NewsArticleService> logger, IMapper mapper, INewsArticleRepository newsArticleRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _newsArticleRepository = newsArticleRepository;
    }

    /// <inheritdoc />
    public async Task<bool> CreateNewsArticle(NewsArticleRequestModel requestModel)
    {
        NewsArticle? mapped = _mapper.Map<NewsArticle>(requestModel);
        mapped.ReleaseDate = DateTime.Now;

        try
        {
            await _newsArticleRepository.AddAsync(mapped);
            await _newsArticleRepository.SaveAsync();
        }
        catch (Exception e)
        {
           _logger.LogError(20, e, "Failed to insert the news article");
           throw new Exception("Could not insert news article");
        }

        return true;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteNewsArticle(int id)
    {
        try
        {
            NewsArticle? newsArticle = await _newsArticleRepository.GetByIdAsync(id);
            if (newsArticle != null)
            {
                _newsArticleRepository.Delete(newsArticle);
                await _newsArticleRepository.SaveAsync();

                return true;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(20, e, $"Failed to delete the news article with id: {id}");
            throw new Exception($"Could not delete the news article with id: {id}");
        }

        return false;
    }

    /// <summary>
    /// Getting list of all news articles.
    /// </summary>
    public async Task<List<NewsArticleResponseModel>> GetList()
    {
        IEnumerable<NewsArticle> newsArticles = await _newsArticleRepository.GetAllAsync();

        List<NewsArticleResponseModel> mapped = _mapper.Map<IEnumerable<NewsArticleResponseModel>>(newsArticles).ToList();

        return mapped;
    }
}
