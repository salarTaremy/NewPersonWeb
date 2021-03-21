using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;
using System.Collections.Generic;

namespace NewPersonWeb.Controllers
{
    public class ShopController : BaseController
    {
        private int CountInPage = 18;
        private string ssn = "0072374586";

        public IActionResult Index()
        {
            Shop shop = new Shop();
            shop.paging.CountInPage = CountInPage;
            shop.paging.CurentPgae = 1;
            shop.Filter.Brands = new ProductRepo().GetBrands(ssn);
            shop = new ShopRepo().GetPage(ssn, shop);
            return View(shop);
        }

        [HttpPost]
        public IActionResult ProductList(int GrpID, List<int> BrandID, string Keyword, byte SortOrder, int CurentPgae)
        {
            if (CurentPgae == 0)
            {
                CurentPgae = 1;
            }

            Shop shop = new Shop();
            shop.paging.CountInPage = CountInPage;
            shop.paging.SortOrder = SortOrder;
            shop.paging.CurentPgae = CurentPgae;
            shop.Filter.Keyword = Keyword;
            shop.Filter.Groups.Add(new ProductGroup { ID = GrpID, Chk = true });
            foreach (var item in BrandID)
            {
                shop.Filter.Brands.Add(new ProductBrand { ID = item, Chk = true });
            }
            shop = new ShopRepo().GetPage(ssn, shop);
            return PartialView("_ProductList", shop);
        }

        [HttpPost]
        public IActionResult AddProductToBasket(long ID_Product, short Qty)
        {

            try
            {

                var buyHistory = new Repository.BasketRepo().GetBuyHistory(ssn, ID_Product);
                if (buyHistory.RemainingQty <= 0)
                {
                    return Ok(new ApiResult
                    {
                        Status = 0,
                        Title = "عملیات نا موفق",
                        Message = "سقف سفارش شما برای این محصول به اتمام رسیده است"
                    });
                }


                BasketRepo basketRepo = new BasketRepo();
                var item = basketRepo.GetBasketDetailIfExistsProduct(ssn, ID_Product);
                if (item != null)
                {
                    return Ok(new ApiResult
                    {
                        Status = 2,
                        Title = "عملیات نا موفق",
                        Message = "این محصول قبلا به  سبد شما اضافه شده است"
                    });
                }

                ShopRepo shopRepo = new ShopRepo();
                Product product = shopRepo.GetProduct(ssn, ID_Product);
                if (product == null)
                {
                    return Ok(new ApiResult
                    {
                        Status = 4,
                        Title = "عملیات نا موفق",
                        Message = "درحال حاضر امکان افزودن این محصول به سبد کالا وجود ندارد"
                    });
                }


                if (product.Inventory == null || product.Inventory <=0  )
                {
                    return Ok(new ApiResult
                    {
                        Status = 5,
                        Title = "عملیات نا موفق",
                        Message = "متاسفانه در حال حاضر موجودی این محصول به اتمام رسیده است"
                    });
                }




                Qty = 1;
                var result = new ShopRepo().AddProductToBasket(ssn, ID_Product, Qty);
                if (result)
                {
                    return Ok(new ApiResult
                    {
                        Status = 1,
                        Title = "عملیات موفق",
                        Message = "محصول مورد نظر با موفقیت به سبد شما اضافه شد"
                    });
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (System.Exception)
            {

                return Ok(new ApiResult
                {
                    Status = 3,
                    Title = "عملیات نا موفق",
                    Message = "متاسفانه عملیات با خطا مواجه شد.لطفا در فرصتی دیگر  نسبت به این کار اقدام بفرمایید"
                });
            }
        }

        [HttpPost]
        public IActionResult AddProductToFavorite(long ID_Product)
        {
            ShopRepo shopRepo = new ShopRepo();
            Product product = shopRepo.GetProduct(ssn, ID_Product);

            if (product == null)
            {
                return Ok(new ApiResult
                {
                    Status = 2,
                    Title = "عملیات با خطا مواجه شد",
                    Message = "محصول معتبر نمیباشد"
                });
            }
            if (product.IsFavorite)
            {
                return Ok(new ApiResult
                {
                    Status = 3,
                    Title = "عملیات انجام نشد",
                    Message = "این محصول قبلا در لیست کالاهای محبوب اضافه شده"
                });
            }

            var result = shopRepo.AddProductToFavorite(ssn, ID_Product);
            if (result)
            {
                return Ok(new ApiResult
                {
                    Status = 1,
                    Title = "عملیات موفق",
                    Message = "محصول مورد نظر با موفقیت به لیست علاقمندی های شما اضافه شد"
                });
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        public IActionResult RemoveProductFromFavorite(long ID_Product)
        {
            ShopRepo shopRepo = new ShopRepo();
            Product product = shopRepo.GetProduct(ssn, ID_Product);

            if (product == null)
            {
                return Ok(new ApiResult
                {
                    Status = 2,
                    Title = "عملیات با خطا مواجه شد",
                    Message = "محصول معتبر نمیباشد"
                });
            }
            if (product.IsFavorite != true)
            {
                return Ok(new ApiResult
                {
                    Status = 3,
                    Title = "عملیات انجام نشد",
                    Message = "این محصول در لیست کالاهای محبوب شما نمیباشد"
                });
            }

            var result = shopRepo.RemoveProductFromeFavorite(ssn, ID_Product);
            if (result)
            {
                return Ok(new ApiResult
                {
                    Status = 1,
                    Title = "عملیات موفق",
                    Message = "محصول مورد نظر با موفقیت از لیست علاقمندی های شما حذف شد"
                });
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("[Controller]/[Action]/{ProductId}")]
        public IActionResult ProductDetail(long ProductId)
        {
            var Product =  new ShopRepo().GetProduct(ssn, ProductId);
            Product.RelatedProducts =  new ProductRepo().GetRelated(ssn, ProductId);
            return View(Product);
        }



        [HttpGet]
        public IActionResult OrderList()
        {
            var Lst = new OrderRepo().GetList(ssn);
            return View(Lst);
        }

        [HttpGet]
        [Route("[Controller]/[Action]/{ID}")]
        public IActionResult OrderDetail(long ID)
        {
            var Lst = new OrderRepo().GetItems(ssn,ID);
            return View(Lst);
        }


    }
}