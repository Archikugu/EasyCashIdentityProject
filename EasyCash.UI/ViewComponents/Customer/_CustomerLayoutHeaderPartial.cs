﻿using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
