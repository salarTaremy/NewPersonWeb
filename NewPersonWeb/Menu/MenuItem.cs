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
        public MenuItem(string Name)
        {
            this.Name = Name;
            this.Items = new List<SubMenu>();
        }
        public string Name { get; set; }
        public List<SubMenu> Items { get; set; }
    }
}
