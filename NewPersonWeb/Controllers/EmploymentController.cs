using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Controllers
{
    
    public class EmploymentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmploymentOrder()
        {
            string ssn = User.Identity.Name;
            var repo = new Repository.EmploymentRepo();
            var EmpOrd = repo.GetEmploymentOrder(ssn);

            Menu.AppMenu.SwichMenu(new Menu.SubMenu { Action = "EmploymentOrder", Controller = "Employment" });
            return View(EmpOrd);
        }

        public IActionResult PayrollList()
        {
            string ssn = User.Identity.Name;
            var repo = new Repository.EmploymentRepo();
            var Lst = repo.GetPayrollList(ssn);

            return View(Lst);
        }

        
        [HttpGet]
        [Route("[Controller]/[Action]/{Id:int}")]
        public IActionResult PayrollDetail(int id)
        {
            var repo = new Repository.EmploymentRepo();
            var Lst = repo.GetPayrollDetail(id);

            return View(Lst);
        }


    }
}
