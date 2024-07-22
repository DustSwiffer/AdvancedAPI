using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;

namespace AdvancedAPI.Data.Repositories;

public class NewsArticleRepository : BaseRepository<NewsArticle>, INewsArticleRepository
{
    /// <summary>
    /// constructor.
    /// </summary>
    public NewsArticleRepository(AdvancedApiContext context)
        : base(context)
    {
    }
}
