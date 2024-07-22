using AdvancedAPI.Data.Models;
using AdvancedAPI.Data.Repositories.Interfaces;
using AdvancedAPI.Data.ViewModels.NewsArticle;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Services;

/// <summary>
/// all tests for <see cref="NewsArticleService"/>.
/// </summary>
public class NewsArticleTests
{
    private readonly IFixture _fixture;
    private readonly INewsArticleService _newsArticleService;
    private readonly Mock<INewsArticleRepository> _newsArticleRepository;
    private readonly Mock<IMapper> _mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public NewsArticleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _newsArticleRepository = _fixture.Freeze<Mock<INewsArticleRepository>>();
        _mapper = _fixture.Freeze<Mock<IMapper>>();
        Mock<ILogger<NewsArticleService>> logger = _fixture.Freeze<Mock<ILogger<NewsArticleService>>>();
        _newsArticleService = new NewsArticleService(logger.Object, _mapper.Object, _newsArticleRepository.Object);
    }

    /// <summary>
    /// CreateNewArticle Creates successfully.
    /// </summary>
    [Fact]
    public async Task CreateNewsArticleCreateSuccessfully()
    {
        NewsArticleRequestModel? requestModel = _fixture.Create<NewsArticleRequestModel>();
        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.AddAsync(It.IsAny<NewsArticle>())).Returns(Task.CompletedTask);
        _newsArticleRepository.Setup(r => r.SaveAsync()).Returns(Task.CompletedTask);

        bool result = await _newsArticleService.CreateNewsArticle(requestModel);

        Assert.True(result);
    }

    /// <summary>
    /// CreateNewsArticle will fail on AddAsync.
    /// </summary>
    [Fact]
    public async Task CreateNewsArticleCreateFailedOnAdd()
    {
        NewsArticleRequestModel? requestModel = _fixture.Create<NewsArticleRequestModel>();
        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.AddAsync(It.IsAny<NewsArticle>())).Returns(Task.CompletedTask);
        _newsArticleRepository.Setup(r => r.SaveAsync()).Throws(It.IsAny<Exception>());

        var exception = await Assert.ThrowsAsync<Exception>(() => _newsArticleService.CreateNewsArticle(requestModel));

        Assert.Equal("Could not insert news article", exception.Message);
    }

    /// <summary>
    /// CreateNewsArticle will fail on SaveChanges.
    /// </summary>
    [Fact]
    public async Task CreateNewsArticleCreateFailedOnSaveChanges()
    {
        NewsArticleRequestModel? requestModel = _fixture.Create<NewsArticleRequestModel>();
        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.AddAsync(It.IsAny<NewsArticle>())).Throws(It.IsAny<Exception>());
        _newsArticleRepository.Setup(r => r.SaveAsync()).Returns(Task.CompletedTask);

        Exception? exception = await Assert.ThrowsAsync<Exception>(() => _newsArticleService.CreateNewsArticle(requestModel));

        Assert.Equal("Could not insert news article", exception.Message);
    }

    /// <summary>
    /// DeleteNewsArticle will returns false after GetById.
    /// </summary>
    [Fact]
    public async Task DeleteNewsArticleDeletesFailedOnNotFound()
    {
        int id = 1;
        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(value: null);

        bool result = await _newsArticleService.DeleteNewsArticle(id);

        Assert.False(result);
    }

    /// <summary>
    /// DeleteNewsArticle will fail on Delete.
    /// </summary>
    [Fact]
    public async Task DeleteNewsArticleDeletesFailedOnDelete()
    {
        int id = 1;
        NewsArticle newsArticle = new NewsArticle
        {
            Id = 1,
            HeaderText = "unit test",
            ContentHtml = "<h1>Unit test being used</h1>",
        };

        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(newsArticle);
        _newsArticleRepository.Setup(r => r.Delete(It.IsAny<NewsArticle>())).Throws(It.IsAny<Exception>());

        Exception? exception = await Assert.ThrowsAsync<Exception>(() => _newsArticleService.DeleteNewsArticle(id));

        Assert.Equal($"Could not delete the news article with id: {id}", exception.Message);
    }

    /// <summary>
    /// DeleteNewArticle will succeed.
    /// </summary>
    [Fact]
    public async Task DeleteNewsArticleSucceed()
    {
        int id = 1;
        NewsArticle newsArticle = new NewsArticle
        {
            Id = 1,
            HeaderText = "unit test",
            ContentHtml = "<h1>Unit test being used</h1>",
        };

        NewsArticle? newsArticleFixture = _fixture.Create<NewsArticle>();
        _mapper.Setup(m => m.Map<NewsArticle>(It.IsAny<NewsArticleRequestModel>())).Returns(newsArticleFixture);
        _newsArticleRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(newsArticle);
        _newsArticleRepository.Setup(r => r.Delete(It.IsAny<NewsArticle>()));

        bool result = await _newsArticleService.DeleteNewsArticle(id);

        Assert.True(result);
    }
}
