using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Menu
{
    public static class AppMenu
    {
        public static List<MenuItem> menu;

        public static  void  SwichMenu(SubMenu NewSubMenu)
        {
            foreach (var item in menu)
            {
                foreach (var Subitem in item.Items)
                {
                    if (Subitem.IsActive)
                    {
                        Subitem.IsActive = false;
                    }
                    if (Subitem.Controller == NewSubMenu.Controller && Subitem.Action == NewSubMenu.Action)
                    {
                        Subitem.IsActive = true;
                    }
                }
            }
        }

    }
}
