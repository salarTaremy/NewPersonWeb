using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewPersonWeb.Filters;
using NewPersonWeb.Menu;
using NewPersonWeb.Models;
using NewPersonWeb.Repository;

namespace NewPersonWeb.Controllers
{

    public class HomeController : BaseController
    {
        [SwichMenu]
        public IActionResult Index()
        {
            InitMenu();
            string ssn = User.Identity.Name;
            var  cus = new CustomerRepo().GetCustomerInfo(ssn);
            return View(cus);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        private void InitMenu()
        {
            AppMenu.menu = new List<MenuItem>();
            
            MenuItem menuItem;
            menuItem = new MenuItem ("خانه", "feather icon-home");
            menuItem.Items.Add(new SubMenu { Name = "اعتبار ریالی", Controller = "Home",  Action = "Index"  , IsActive = true ,IconClass = "feather icon-activity" });
            AppMenu.menu.Add(menuItem);

            menuItem = new MenuItem("فروشگاه", "fa fa-shopping-basket");
            menuItem.Items.Add(new SubMenu { Name = "محصولات", Controller = "Shop", Action = "Index", IsActive = false, IconClass = "feather icon-package" });
            menuItem.Items.Add(new SubMenu { Name = "سبد خرید", Controller = "Basket", Action = "Index", IsActive = false, IconClass = "fa fa-shopping-cart" });
            menuItem.Items.Add(new SubMenu { Name = "سوابق خرید", Controller = "Shop", Action = "OrderList", IsActive = false, IconClass = "fa fa-credit-card" });
            AppMenu.menu.Add(menuItem);

            menuItem = new MenuItem("سوابق حقوق", "fa fa-id-card-o");
            menuItem.Items.Add(new SubMenu { Name = "فیش های حقوقی", Controller = "Employment", Action = "PayrollList", IsActive = false, IconClass = "fa fa-newspaper-o" });
            menuItem.Items.Add(new SubMenu { Name = "حکم کارگزینی", Controller = "Employment", Action = "EmploymentOrder", IsActive = false, IconClass = "fa fa-id-card-o" });
            AppMenu.menu.Add(menuItem);


            //menuItem = new MenuItem("مرخصی و ماموریت", "fa fa-calendar");
            //menuItem.Items.Add(new SubMenu { Name = "فهرست مرخصی و ماموریت روزانه", Controller = "#", Action = "#", IsActive = false, IconClass = "fa fa-window-maximize" });
            //menuItem.Items.Add(new SubMenu { Name = "کاردکس مرخصی", Controller = "#", Action = "#", IsActive = false, IconClass = "fa fa-calendar" });
            //AppMenu.menu.Add(menuItem);

            //menuItem = new MenuItem("ورود و خروج", "fa fa-retweet");
            //menuItem.Items.Add(new SubMenu { Name = "فهرست تردد روزانه", Controller = "#", Action = "#", IsActive = false, IconClass = "fa fa-calendar-o" });
            //menuItem.Items.Add(new SubMenu { Name = "عدم ثبت ورود/خروج", Controller = "#", Action = "#", IsActive = false, IconClass = "fa fa-calendar-times-o" });
            //menuItem.Items.Add(new SubMenu { Name = "کسر کار و اضافه کار", Controller = "#", Action = "#", IsActive = false, IconClass = "fa fa-calendar-minus-o" });
            //AppMenu.menu.Add(menuItem);

        }

    }
}
