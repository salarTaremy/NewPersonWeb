using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class ProductFilter
    {
        public ProductFilter()
        {
            this.Groups = new List<ProductGroup>();
            this.Brands = new List<ProductBrand>();
        }
        public string Keyword { get; set; }

        public List<ProductBrand> Brands { get; set; }

        public List<ProductGroup> Groups { get; set; }
    }

}
