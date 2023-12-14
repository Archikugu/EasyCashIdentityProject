using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.Controllers
{
    public class ElectricBillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
