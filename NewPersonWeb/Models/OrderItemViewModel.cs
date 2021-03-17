using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class OrderItemViewModel
    {

        public long ProductID { get; set; }
		public string ProductCode { get; set; }
		public string Brand { get; set; }
		public string name { get; set; }
		public long Qty { get; set; }
		public long Price { get; set; }
		public long TotalPrice { get; set; }
		public byte ProductType { get; set; }
		public byte Rate { get; set; }
		public bool HaveFactor { get; set; }
		public bool HaveFactorItem { get; set; }
		
	}
}
