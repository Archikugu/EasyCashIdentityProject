﻿using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
