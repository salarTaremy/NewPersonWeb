using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Controllers
{
    public class BasketController: BaseController
    {
        private string ssn = "0072374586";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BasketItems()
        {
            var x = new BasketRepo().GetListOfBasketProducts(ssn);
            return PartialView("_BasketItems" , x);
        }

        [HttpPost]
        public IActionResult ChangeQty(long ProductID, int Qty)
        {
            var history = new BasketRepo().GetBuyHistory(ssn, ProductID);
            var x = new BasketRepo().GetListOfBasketProducts(ssn);
            //var y = new List<Models.Product>();
            //y.Add(x.FirstOrDefault());
            return PartialView("_BasketItems",x);
        }



    }
}
