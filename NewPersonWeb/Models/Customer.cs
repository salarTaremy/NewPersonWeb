using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewPersonWeb.Models
{
    public class Customer:BaseEntity<int>
    {

		[Display(Name="نام")]
        public string Name { get; set; }
		[Display(Name = "نام خانوادگی")]
		public string Famil { get; set; }
		[Display(Name = "شماره  شناسنامه")]
		public string Sh_Sh { get; set; }
		[Display(Name = "تاریخ تولد")]
		public int BirthDay { get; set; }
		[Display(Name = "کد ملی")]
		public string Code_meli { get; set; }
		[Display(Name = "نوع مشتری")]
		public string CustomerTypeName { get; set; }
		[Display(Name = "کد مشتری")]
		public string CustomerCode { get; set; }


	}
}
