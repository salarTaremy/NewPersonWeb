using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class BasketViewModel 
    {
        public BasketViewModel()
        {
            this.Items = new List<Product>();
        }

        public List<Product> Items { get; set; }
        public Basket basket { get; set; }
        public Customer customer { get; set; }
        public long Total { get; set; }
        public long TotalConsumer { get; set; }
        public long Tax { get; set; }
    }
}
