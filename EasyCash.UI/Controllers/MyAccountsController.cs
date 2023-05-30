using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.Controllers
{
    public class MyAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
