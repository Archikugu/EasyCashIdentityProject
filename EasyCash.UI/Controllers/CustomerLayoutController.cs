using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
