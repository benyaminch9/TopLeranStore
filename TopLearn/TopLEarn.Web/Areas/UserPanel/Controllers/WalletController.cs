using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services;
using TopLearn.Core.Services.Interfaces;

namespace TopLEarn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private IUserServices _userServices;
        public WalletController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.ListWallet = _userServices.GetWalletUser(User.Identity.Name);
            return View();
        }

        [Route("UserPanel/Wallet")]
        [HttpPost]
        public ActionResult Index(ChargeWalletViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = _userServices.GetWalletUser(User.Identity.Name);
                return View(charge);
            }
            _userServices.ChageWallet(User.Identity.Name, charge.Amount, "شارژ حساب");

            //ToDo Online Payment
            return null;
        }
    }
}
