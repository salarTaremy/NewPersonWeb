using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;

namespace NewPersonWeb.Controllers
{

    public class LoginController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View( new TarafHesab { Id = 0 ,CodeMelli = ""});
        }
        [HttpPost]
        public IActionResult Index(TarafHesab Th)
        {
            if (Th.CodeMelli == "0072374586")
            {
                Th.ErrorMessageForLogin = "کد ملی شما در سامانه ثبت نشده است";
                return View(Th);
            }
            if (Th.WebPassword == "5879")
            {
                Th.ErrorMessageForLogin = "رمز عبور شما صحیح نمی  باشد";
                return View(Th);
            }
            Th.FullName = "Salar";
            //HttpContext.Session.SetInt32("Th_ID", (int)Th.Id);
            HttpContext.Session.SetInt32("Th_ID", 256);
            HttpContext.Session.SetString("Th_Name", Th.FullName);

            return RedirectToAction("index", "home");
        }
    }
}
