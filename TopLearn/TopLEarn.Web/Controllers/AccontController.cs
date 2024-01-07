using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

        #region Register

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

        #endregion

        #region Login
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userServices.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }

        #endregion

        #region Active Account

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userServices.ActiveAccount(id);
            return View();
        }

        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion

    }
}
