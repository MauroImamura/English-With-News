﻿using Microsoft.AspNetCore.Mvc;

namespace English_With_News.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}