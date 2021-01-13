using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        public IActionResult ChangeQty(long ProductID, short Qty)
        {
            var rep = new BasketRepo();


            var history = rep.GetBuyHistory(ssn, ProductID);

            if (history.RemainingQty == 0 )
            {
                return Ok(new ApiResult { Status = 3, Title = "عملیات ناموفق", Message = "سقف سفارش شما برای خرید این محصول به اتمام رسیده است" });
            }

            if (history.RemainingQty < Qty )
            {

                return Ok(new ApiResult { Status = 4, Title = "عملیات ناموفق", Message = $"سقف سفارش شما برای این محصول {history.RemainingQty} عدد میباشد" });
            }


            if (rep.ChangeQty(this.ssn,ProductID,Qty ))
            {
                return Ok(new ApiResult { Status = 1, Title = "عملیات موفق", Message = "تعداد این محصول با موفقیت تغییر یافت" });
            }
            else
            {
                return Ok(new ApiResult { Status = 5, Title = "عملیات ناموفق", Message = $"متاسفانه عملیات انجام نشد" });
            }


            
            

        }



    }
}
