using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
	public class BasketDetail:BaseEntity<int>
	{
		public int ID_Basket { get; set; }
		public long ID_Product { get; set; }
		public short Qty { get; set; }

	}
}
