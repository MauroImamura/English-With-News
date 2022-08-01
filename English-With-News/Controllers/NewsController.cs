using English_With_News.Models;
using English_With_News.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public string Meaning(string word)
        {
            string ans = "";
            string apiAns = _newsRepository.Meaning(word).Result;
            apiAns = apiAns.Remove(apiAns.Length-1).Substring(1);
            
            if(apiAns != null)
            {
                ans = apiAns;
            }

            return ans;
        }
    }
}
