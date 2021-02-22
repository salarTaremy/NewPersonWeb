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
            BasketViewModel basketVM = new BasketViewModel();
            basketVM.Items = new BasketRepo().GetListOfBasketProducts(ssn);
            basketVM.basket= new BasketRepo().GetBasket(ssn);
            basketVM.customer = new CustomerRepo().GetCustomerInfo(ssn);
            foreach (var item in basketVM.Items)
            {
                
                basketVM.TotalConsumer += (item.Qty * item.ConsumerPrices);
                basketVM.Total += (item.Qty * item.Price);
                if (item.HaveTax)
                {
                    basketVM.Tax += (item.Qty * item.Price) *  item.TaxPercentage / 100;
                }
                
            }

            return PartialView("_BasketItems" , basketVM);
        }


        [HttpPost]
        public IActionResult RemoveProductFromBasket(long ID_Product)
        {

            var result = new BasketRepo().RemoveProductFromBasket(ssn, ID_Product);
            if (result)
            {
                return Ok(new ApiResult
                {
                    Status = 1,
                    Title = "عملیات موفق",
                    Message = "محصول مورد نظر با موفقیت از سبد شما حذف شد"
                });
            }
            else
            {
                return Ok(new ApiResult
                {
                    Status = 2,
                    Title = "عملیات با خطا مواجه شد",
                    Message = "محصول مورد نظر از سبد شما حذف نشد نمیباشد"
                });
            }
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
                return Ok(new ApiResult { Status = 1, Title = "عملیات موفق", Message = $"تعداد این محصول به {Qty} عدد تغییر یافت" });
            }
            else
            {
                return Ok(new ApiResult { Status = 5, Title = "عملیات ناموفق", Message = $"متاسفانه عملیات انجام نشد" });
            }

        }

    }
}
