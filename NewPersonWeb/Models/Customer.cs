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

		[Display(Name = "اعتبار اولیه")]
		public long DefaultCreditRls { get; set; }
		[Display(Name = "مبلغ درخواست باز")]
		public long OrderRls { get; set; }
		[Display(Name = "مبلغ فاکتور باز")]
		public long FactorRls { get; set; }
		[Display(Name = "مانده بدهی حسابداری")]
		public long AccountingRls { get; set; }






	}
}
