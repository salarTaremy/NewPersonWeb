using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Authentication;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;

namespace NewPersonWeb.Controllers
{

    public class LoginController : Controller
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
            TarafHesab th = new TarafHesab { Id = 0, Code_melli = "", RememberMe = false };
            if (User.Identity.IsAuthenticated)
            {
                th.Code_melli = User.Identity.Name;
                th.RememberMe = true;
            }


            return View(th);
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
                bool IsResetPass = Authentication.PasswordManager.ISValidToken(Th.Code_melli, Th.WebPassword);
                if (!IsResetPass)
                {
                    Th.ErrorMessageForLogin = "رمز عبور یا نام کاربری صحیح نمیباشد";
                    return View(Th);
                }
            }


            await _signInManager.SignInAsync(user, Th.RememberMe);
            HttpContext.Session.SetString("FullName", user.FullName);
            HttpContext.Session.SetString("UserID", user.Id);
            //SendWelcomeSms("0912XXXXXXXX");
            return RedirectToAction("index", "home");
        }



        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View( new TarafHesab());
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword(TarafHesab Th)
        {
            var res = new ApiResult();

            if (Th is null)
            {
                res.Message = "اطلاعات شما معتبر نمیباشد";
                return View("NotAuthorized", res);
            }

            if (Th.Code_melli is null  || Th.Sh_Sh is null ||Th.Mobile is null  )
            {
                res.Message = "اطلاعات شما معتبر نمیباشد";
                return View( "NotAuthorized" , res);
            }

            ThRepo rep = new ThRepo();
             TarafHesab ExistTh =  rep.GetTarafHesab(Th.Code_melli);

            if (ExistTh is null)
            {
                res.Message = "اطلاعات شما معتبر نمیباشد";
                return View("NotAuthorized", res);
            }



            if (ExistTh.Code_melli.Trim() == Th.Code_melli.Trim() && 
                ExistTh.Sh_Sh.Trim() == Th.Sh_Sh.Trim() && 
                ExistTh.Mobile.Trim() == Th.Mobile.Trim())
            {
                string token =  Authentication.PasswordManager.AddToken(ExistTh.Code_melli);
                if (token != null)
                {

                    int ValidTime = PasswordManager.ValidTime / 60;
                    Farapayamak.SMS sms = new Farapayamak.SMS();
                    string Msg = $"ایران آوند فر \n رمز عبور شما: {token}  \n اعتبار {ValidTime.ToString()} دقیقه";
                    sms.SendMessageAsync(ExistTh.Mobile, Msg);
                    //return RedirectToAction("Success");

                    Th.SuccessMessage = "رمز عبور جدید برای شما پیامک شد";
                    HttpContext.Session.SetString("UserID", Th.Code_melli);
                    return View("ResetPassword", Th);
                }
                else
                {
                    res.Message = "درحال حاضر سیستم قادر به بازیابی رمز عبور شما نمیباشد";
                    return View("NotAuthorized", res);
                }

                
            }
            else
            {
                res.Message = "اطلاعات شما معتبر نمیباشد";
                return View("NotAuthorized", res);
            }

        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View(new TarafHesab());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(TarafHesab th)
        {
            try
            {
                string UserID = HttpContext.Session.GetString("UserID");
                if (UserID is null || UserID == "")
                {
                    return RedirectToAction("Index");
                }
                ThRepo thRepo = new ThRepo();
                bool IsAuthenticated = User.Identity.IsAuthenticated;
                if (!IsAuthenticated)
                {
                    if (th.ResetToken is null)
                    {
                        th.ErrorMessageForLogin = "رمز فعلی نا معتبر است";
                        return View(th);
                    }
                    if (th.WebPassword.Trim() != th.ConfirmWebPassword.Trim())
                    {
                        th.ErrorMessageForLogin = "رمز عبور جدید نا معتبر است";
                        return View(th);
                    }
                    if (th.ResetToken.Trim() == th.ConfirmWebPassword.Trim())
                    {
                        th.ErrorMessageForLogin = "رمز عبور جدید نمیتواند با رمز فعلی یکسان باشد";
                        return View(th);
                    }
                    if (!PasswordManager.ISValidToken(UserID, th.ResetToken))
                    {
                        th.ErrorMessageForLogin = "رمز عبور فعلی نا  معتبر میباشد";
                        return View(th);
                    }

                }
                else
                {
                    TarafHesab ExistsTh = thRepo.GetTarafHesab(UserID.Trim());

                    if (ExistsTh.WebPassword.Trim() != th.ResetToken.Trim())
                    {
                        th.ErrorMessageForLogin = "رمز عبور فعلی نا  معتبر میباشد";
                        return View(th);
                    }
                    if (th.WebPassword.Trim() != th.ConfirmWebPassword.Trim())
                    {
                        th.ErrorMessageForLogin = "رمز عبور جدید با تکرار رمز عبور مغایرت دارد";
                        return View(th);
                    }
                    int PassLen = 4;
                    if (th.WebPassword.Trim().Length < PassLen)
                    {
                        th.ErrorMessageForLogin = $"رمز عبور جدید باید حداقل{PassLen} کاراکتر باشد";
                        return View(th);
                    }

                }

                bool ChangeThPass = thRepo.ChangeThPass(UserID, th.ConfirmWebPassword);
                if (ChangeThPass)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Success");
                }
                else
                {
                    th.ErrorMessageForLogin = "متاسفانه درحال حاضر امکان تغییر رمز وجود ندارد";
                    return View(th);
                }



            }
            catch (Exception)
            {
                return RedirectToAction("NotAuthorized");
            }


        }




        [AllowAnonymous]
        [HttpGet]
        public IActionResult NotAuthorized()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }



        private async Task<bool> SendWelcomeSms( string Tel)
        {
            string Message = "ورود به سیستم ایران آوندفر";
            Message += "\n";
            Message += DateTime.Now.ToString();
            new Farapayamak.SMS().SendMessage(Tel, Message);

            return true;
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
