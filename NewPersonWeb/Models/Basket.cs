using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
	public class Basket : BaseEntity<int>
	{
        public Basket()
        {
			//this.Details = new List<BasketDetail>();
        }
		public string Ssn { get; set; }
		public string Description { get; set; }
		public string OrderID { get; set; }

		public IEnumerable<BasketDetail> Details;
	}
}
