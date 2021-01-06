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

       
        public IActionResult Index()
        {
          

            return View();
           
        }
        [HttpPost]

        public IActionResult BasketItems()
        {
            var x = new ProductRepo().GetListOfBasketProducts("0072374586");

            return PartialView("_BasketItems" , x);


        }





    }
}
