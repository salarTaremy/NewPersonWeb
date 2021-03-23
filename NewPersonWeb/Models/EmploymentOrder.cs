using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class EmploymentOrder
    {
		[Display(Name = "شناسه")]
		public long id { get; set; }
		[Display(Name = "کد پرسنلی")]
		public long ID_Pr { get; set; }
		[Display(Name = "کد طرف حساب")]
		public long ID_TarafHesab { get; set; }
		[Display(Name = "شماره بیمه")]
		public string ShomarehBime { get; set; }
		[Display(Name = "نام")]
		public string Name { get; set; }
		[Display(Name = "نام خانوادگی")]
		public string Famil { get; set; }
		[Display(Name = "نام پدر")]
		public string NamePedar { get; set; }
		[Display(Name = "شماره شناسنامه")]
		public string Sh_Sh { get; set; }
		[Display(Name = "تاریخ تولد")]
		public string BirthDate { get; set; }
		[Display(Name = "تاریخ استخدام")]
		public string Estekhdam { get; set; }
		[Display(Name = "پایه حقوق روزانه")]
		public long BasicSalaryPerDayRls { get; set; }
		[Display(Name = "پایه حقوق ماهانه")]
		public long BasicSalaryPerMonthRls { get; set; }
		[Display(Name = "حق اولاد")]
		public int MabOladRls { get; set; }
		[Display(Name = "بن کارگری")]
		public int MabBoneKargari { get; set; }
		[Display(Name = "حق مسکن")]
		public int MabMaskan { get; set; }
		[Display(Name = "مبلغ هر ساعت اضافه کار")]
		public int MabEzafeKarPerHour { get; set; }
		[Display(Name = "شرکت")]
		public string Company { get; set; }
		[Display(Name = "کارگاه")]
		public string kargah { get; set; }
		[Display(Name = "تحصیلات")]
		public string Tahsilat { get; set; }
		[Display(Name = "شغل/سمت سازمانی")]
		public string JobName { get; set; }
		[Display(Name = "جنسیت")]
		public string Gender { get; set; }
		[Display(Name = "همراه")]
		public string Mobile { get; set; }
		[Display(Name = "تلفن")]
		public string tel { get; set; }
		[Display(Name = "آقا/خانم")]
		public string GenderName { get; set; }
        public int GenderID { get; set; }

    }
}
