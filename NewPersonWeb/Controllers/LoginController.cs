using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;

namespace NewPersonWeb.Controllers
{

    public class LoginController : BaseController
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            return View(new TarafHesab { Id = 0, Code_melli = "" });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(TarafHesab Th)
        {
            await _signInManager.SignOutAsync();
            if (IsValidSsn(Th.Code_melli) == false)
            {
                Th.ErrorMessageForLogin = "کد ملی وارد شده معتبر نمی  باشد";
                return View(Th);
            }

            var user = await _userManager.FindByNameAsync(Th.Code_melli);

            if (user is null)
            {
                Th.ErrorMessageForLogin = " کد ملی در سیستم ثبت نشده است";
                return View(Th);

            }
            if (user.WebPassword.Trim() != Th.WebPassword.Trim())
            {
                Th.ErrorMessageForLogin = "رمز عبور یا نام کاربری صحیح نمیباشد";
                return View(Th);
            }

            await _signInManager.SignInAsync(user, false);




            //HttpContext.Session.SetInt32("Th_ID", (int)Th.Id);
            HttpContext.Session.SetInt32("Th_ID", 256);
            HttpContext.Session.SetString("FullName", user.FullName);

            return RedirectToAction("index", "home");
        }


        private bool IsValidSsn(string ssn)
        {
            try
            {
                char[] chArray = ssn.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (ssn)
                {
                    case "0000000000":
                    case "1111111111":
                    case "2222222222":
                    case "3333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return false;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
