using English_With_News.Models;
using English_With_News.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace English_With_News.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        public NewsController(INewsRepository repository)
        {
            _newsRepository = repository;
        }

        public IActionResult Index()
        {
            NewsList newsList = new NewsList();
            newsList.currentNews = _newsRepository.CreateNewsList();
            return View(newsList);
        }

        [HttpPost]
        public void Meaning(string word)
        {
            _newsRepository.Meaning(word);
        }
    }
}
