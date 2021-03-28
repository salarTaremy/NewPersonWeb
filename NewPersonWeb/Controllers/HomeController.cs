using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;

namespace NewPersonWeb.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            string ssn = User.Identity.Name;
            var  cus = new CustomerRepo().GetCustomerInfo(ssn);
            return View(cus);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
