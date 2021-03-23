using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Controllers
{
    public class EmploymentController : BaseController
    {

        private string ssn = "0072374586";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmploymentOrder()
        {
            var repo = new Repository.EmploymentRepo();
            var EmpOrd = repo.GetEmploymentOrder(ssn);

            return View(EmpOrd);
        }

        public IActionResult PayrollList()
        {
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
