using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Menu
{
    public class SubMenu
    {
        public SubMenu()
        {
            this.Action = "Index";
            this.IsActive = false;
        }

        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool IsActive { get; set; }
        public string IconClass { get; set; }
        public string Class()
        {
            if (IsActive)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }



    }
}
