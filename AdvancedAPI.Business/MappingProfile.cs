using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using AdvancedAPI.Data.ViewModels.User;
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
        CreateMap<NewsArticle, NewsArticleResponseModel>();
        CreateMap<User, UserProfileResponseModel>(MemberList.None)
            .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender.Name));
    }
}
