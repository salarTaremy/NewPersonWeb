using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class Shop
    {
        public Shop()
        {
            this.Filter = new ProductFilter();
            this.Products = new List<Product>();
            this.paging = new Paging();
        }
        public List<Product> Products { get; set; }
        public ProductFilter Filter { get; set; }
        public Paging paging { get; set; }


    }
}
