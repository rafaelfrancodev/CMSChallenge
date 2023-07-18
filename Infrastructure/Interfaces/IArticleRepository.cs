using CMSChallenge.Models;

namespace CMSChallenge.Infrastructure.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> GetArticleWithKeywords(int id);
        Task<List<Article>> GetAllArticles();
    }
}
