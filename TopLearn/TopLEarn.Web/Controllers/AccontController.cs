using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services;

namespace TopLEarn.Web.Controllers
{
    public class AccontController : Controller
    {
        private UserServices _userServices;
        public AccontController(UserServices userServices)
        {
            _userServices = userServices;
        }
        public IActionResult Resgister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Resgister(RegisterViewModel resgister)
        {
            if (!ModelState.IsValid)
            {
                return View(resgister);
            }

            if(_userServices.IsExistUserName(resgister.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری قبلا استفاده شده است");
                return View(resgister);
            }

            if (_userServices.IsExistEmail(FixedText.FixEmail(resgister.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(resgister);
            }
            return View();
        }
    }
}
