﻿using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using NewPersonWeb.Filters;
using System.Threading;

namespace NewPersonWeb.Controllers
{
    public class BasketController: BaseController
    {

        [SwichMenu]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BasketItems()
        {
            string ssn = User.Identity.Name;
            BasketViewModel basketVM = GetBasketViewModel(ssn);
            if (basketVM.Items.Count == 0)
            {
                return  PartialView("_Empty");
            }

            return PartialView("_BasketItems" , basketVM);
        }

        [HttpPost]
        public IActionResult RemoveProductFromBasket(long ID_Product)
        {
            string ssn = User.Identity.Name;
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
            string ssn = User.Identity.Name;
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

            if (rep.ChangeQty(ssn,ProductID,Qty ))
            {
                return Ok(new ApiResult { Status = 1, Title = "عملیات موفق", Message = $"تعداد این محصول به {Qty} عدد تغییر یافت" });
            }
            else
            {
                return Ok(new ApiResult { Status = 5, Title = "عملیات ناموفق", Message = $"متاسفانه عملیات انجام نشد" });
            }

        }



        [HttpPost]
        public IActionResult Confirm(string description)
        {
            try
            {
                string ssn = User.Identity.Name;
                BasketViewModel basketVM = GetBasketViewModel(ssn);

                if (basketVM.basket is null)
                {
                    return PartialView("_error", "این سبد در حال حاضر وجود ندارد یا قبلا تایید شده است");
                }
                if (basketVM.basket.OrderID != null)
                {
                    return PartialView("_error", "سبد فعلی قبلا تایید شده است");
                }
                if (basketVM.Items.Count == 0)
                {
                    return PartialView("_error", "هیچ محصولی در سبد فعلی وجود ندارد");
                }
                if (basketVM.customer is null)
                {
                    return PartialView("_error", "هیچ محصولی در سبد فعلی وجود ندارد");
                }
                long Balance = basketVM.customer.CurrentCredit - (basketVM.Total + basketVM.Tax);
                if (Balance < 0)
                {
                    return PartialView("_error", "اعتبار مالی شما کافی نیست");
                }

                var rep = new BasketRepo();

                if (rep.ConfirmBasket(basketVM.basket.ID,ssn , description))
                {
                    SendConfirmSms(basketVM);
                    return PartialView("_Success", "سفارش شما با موفقیت ثبت شد");
                }
                else
                {
                    return PartialView("_error", "متاسفانه سفارش شما ثبت نشد");
                }
            }
            catch (Exception)
            {

                return PartialView("_error", "متاسفانه ثبت سفارش شما با خطا مواجه شد");
            }

             
            
        }


        private BasketViewModel GetBasketViewModel(string ssn)
        {
            BasketViewModel basketVM = new BasketViewModel();
            basketVM.Items = new BasketRepo().GetListOfBasketProducts(ssn);
            basketVM.basket = new BasketRepo().GetBasket(ssn);
            basketVM.customer = new CustomerRepo().GetCustomerInfo(ssn);
            //basketVM.Total = 0;
            //basketVM.TotalConsumer = 0;
            //basketVM.Tax = 0;
            foreach (var item in basketVM.Items)
            {
                basketVM.TotalConsumer += (item.Qty * item.ConsumerPrices);
                basketVM.Total += (item.Qty * item.Price);
                if (item.HaveTax)
                {
                    basketVM.Tax += (item.Qty * item.Price) * item.TaxPercentage / 100;
                }
            }
            return basketVM;
        }




        public static async void SendConfirmSms(BasketViewModel BVM)
        {
            try
            {
                string Mob = BVM.customer.Mobile;
                string Message = "سفارش شما با موفقیت ثبت شد";
                Message += "\n";
                Message += "ایران آوند فر";
                Message += "\n";
                Message += $"تراکنش:{BVM.basket.ID.ToString()}";
                Farapayamak.SMS SMS = new Farapayamak.SMS();
                await SMS.SendMessageAsync(Mob, Message);
            }
            catch (Exception)
            {
                //throw;
            }
        }



    }
}
