using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Menu
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new List<SubMenu>();
        }
        public MenuItem(string Name ,string IconClass)
        {
            this.Name = Name;
            this.IconClass = IconClass;
            this.Items = new List<SubMenu>();
        }
        public string Name { get; set; }

        public string IconClass { get; set; }
        public List<SubMenu> Items { get; set; }
    }
}
