using Business.Abstract;
using DataAccess.Concrete;
using DTO.Dtos.CustomerAccountProcessDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.UI.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerProcessDto sendMoneyForCustomerProcessDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            sendMoneyForCustomerProcessDto.SenderID = user.Id;
            sendMoneyForCustomerProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerProcessDto.ProcessType = "Remittance";
            sendMoneyForCustomerProcessDto.ReceiverID = receiverAccountNumberID;

            // _customerAccountProcessService.TInsert();

            return RedirectToAction("Index", "Deneme");
        }
    }
}
