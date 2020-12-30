using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;

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
            Qty = 1;
            var result = new ShopRepo().AddProductToBasket(ssn, ID_Product, Qty);
            if (result)
            {
                //return Ok(true);
                return Ok(new { status = 1 , Msg = "اضافه شد"});
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        public IActionResult AddProductToFavorite(long ID_Product)
        {
            var result = new ShopRepo().AddProductToFavorite(ssn, ID_Product);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        public IActionResult RemoveProductFromFavorite(long ID_Product)
        {
            var result = new ShopRepo().RemoveProductFromeFavorite(ssn, ID_Product);
            if (result)
            {
                return Ok(true);
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
            var Product = new ShopRepo().GetProduct(ssn, ProductId);
            Product.RelatedProducts = new ProductRepo().GetRelated(ssn, ProductId);
            return View(Product);
        }
    }
}