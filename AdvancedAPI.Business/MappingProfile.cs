using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using AutoMapper;

namespace Business;

/// <summary>
/// Auto mapper profiles.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Mapping Models against entities and opposite.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<NewsArticleRequestModel, NewsArticle>();
    }
}
