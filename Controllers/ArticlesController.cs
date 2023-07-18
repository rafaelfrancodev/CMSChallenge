using CMSChallenge.Infrastructure.Context;
using CMSChallenge.Infrastructure.Interfaces;
using CMSChallenge.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CMSChallenge.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _repository.GetAllArticles();
            return View(articles);
        }



        public async Task<IActionResult> Detail(int id)
        {
            var article = await _repository.GetArticleWithKeywords(id);
            return View(article);
        }
    }
}
