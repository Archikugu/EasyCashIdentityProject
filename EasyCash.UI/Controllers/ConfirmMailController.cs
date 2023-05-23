using EasyCash.UI.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EasyCash.UI.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.mail = value;
            //confirmMailViewModel.Mail = value.ToString();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var value = TempData["Mail"];
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
