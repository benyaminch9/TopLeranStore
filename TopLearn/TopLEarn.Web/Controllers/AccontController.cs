using Microsoft.AspNetCore.Mvc;
using System;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Generate;
using TopLearn.Core.Security;
using TopLearn.Core.Services;
using TopLearn.DataLayer;
using TopLearn.DataLayer.Entities.User;

namespace TopLEarn.Web.Controllers
{
    public class AccontController : Controller
    {
        private UserServices _userServices;
        public AccontController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel resgister)
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

            User user = new User()
            {
                ActiveCode=NameGenerator.GenerateUniqCode(),
                Email=FixedText.FixEmail(resgister.Email),
                IsActive=false,
                Password=PasswordHelper.EncodePasswordMd5(resgister.Password),
                RegisterDate=DateTime.Now,
                UserAvatar= "Defult.jpg",
                UserName=resgister.UserName
            };
            _userServices.AddUser(user);
            return View("SuccessRegister",user);
        }
    }
}
