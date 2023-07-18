using CMSChallenge.Infrastructure.Context;
using CMSChallenge.Infrastructure.Interfaces;
using CMSChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSChallenge.Infrastructure.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticlesContext _context;


        public ArticleRepository(ArticlesContext context)
        {
            _context = context;
        }

        public async Task<Article> GetArticleWithKeywords(int id)
        {

            var article = await _context.Articles
            .FirstOrDefaultAsync(a => a.Id == id);

            if (article == null)
            {
                return default;
            }

            var keywords = await _context.ArticleKeywords.Where(x => x.ArticleId == id).Select(x => x.KeywordId).ToListAsync();
            var relatedArticles = await _context.ArticleKeywords.Include(x => x.Article).Where(x => keywords.Contains(x.KeywordId) && x.ArticleId != id).ToListAsync();

            article.ArticleKeywords = relatedArticles;

            return article;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _context.Articles.Include(a => a.ArticleKeywords).ToListAsync();
        }

    }
}
