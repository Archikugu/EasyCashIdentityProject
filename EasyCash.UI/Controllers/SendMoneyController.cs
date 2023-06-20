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
        public IActionResult Index(string myCurrency)
        {
            ViewBag.Currency = myCurrency;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerProcessDto sendMoneyForCustomerProcessDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerProcessDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var senderAccountNumberID = context.CustomerAccounts.Where(x => x.AppUserID == user.Id).Where(y => y.CustomerAccountCurrency == "Turkish Lira").Select(z => z.CustomerAccountID).FirstOrDefault();


            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Remittance";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerProcessDto.Amount;
            values.Description = sendMoneyForCustomerProcessDto.Description;
            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }
        //[HttpGet]

    }
}
