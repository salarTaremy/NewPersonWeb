using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class ProductBrand:BaseEntity<int>
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public bool Chk { get; set; }
    }
}
