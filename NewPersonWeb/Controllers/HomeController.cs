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
            menuItem = new MenuItem ("خانه");
            menuItem.Items.Add(new SubMenu { Name = "اعتبار ریالی", Controller = "Home",  Action = "Index"  , IsActive = true });
            AppMenu.menu.Add(menuItem);

            menuItem = new MenuItem("فروشگاه");
            menuItem.Items.Add(new SubMenu { Name = "محصولات", Controller = "Shop", Action = "Index", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "سبد خرید", Controller = "Basket", Action = "Index", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "سوابق خرید", Controller = "Shop", Action = "OrderList", IsActive = false });
            AppMenu.menu.Add(menuItem);

            menuItem = new MenuItem("سوابق حقوق");
            menuItem.Items.Add(new SubMenu { Name = "فیش های حقوقی", Controller = "Employment", Action = "PayrollList", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "حکم کارگزینی", Controller = "Employment", Action = "EmploymentOrder", IsActive = false });
            AppMenu.menu.Add(menuItem);


            menuItem = new MenuItem("مرخصی و ماموریت");
            menuItem.Items.Add(new SubMenu { Name = "فهرست مرخصی و ماموریت روزانه", Controller = "#", Action = "#", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "کاردکس مرخصی", Controller = "#", Action = "#", IsActive = false });
            AppMenu.menu.Add(menuItem);

            menuItem = new MenuItem("ورود و خروج");
            menuItem.Items.Add(new SubMenu { Name = "فهرست تردد روزانه", Controller = "#", Action = "#", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "عدم ثبت ورود/خروج", Controller = "#", Action = "#", IsActive = false });
            menuItem.Items.Add(new SubMenu { Name = "کسر کار و اضافه کار", Controller = "#", Action = "#", IsActive = false });
            AppMenu.menu.Add(menuItem);

        }

    }
}
