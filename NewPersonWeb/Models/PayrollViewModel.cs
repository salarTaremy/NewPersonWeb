using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class PayrollViewModel
    {
        public PayrollViewModel()
        {
			this.IncParams = new List<parameter>();
			this.DecParams = new List<parameter>();
			this.Details = new List<Detail>();
		}

        public List<parameter> IncParams { get; set; }
		public List<parameter> DecParams { get; set; }
		public List<Detail> Details { get; set; }
		public Header header { get; set; }

		public List<Loan> Loans { get; set; }


		public class parameter : BaseEntity<int>
        {
            public string Name { get; set; }
            public long Value { get; set; }
        }

		public class Detail : BaseEntity<int>
		{
			public string Name { get; set; }
			public long Rls { get; set; }
			public int D { get; set; }
			public int H { get; set; }
			public int M { get; set; }
			public int Value { get; set; }
		}
		public class Header:BaseEntity<int>
		{
			public long Counter { get; set; }
			public DateTime CreateDate { get; set; }
			public string HOST_NAME { get; set; }
			public string APP_NAME { get; set; }
			public int ID_WorkPerMonth { get; set; }
			public short ID_MonthOfSalary { get; set; }
			public long ID_Person { get; set; }
			public long ID_Hokm { get; set; }
			public short DayCount { get; set; }
			public long MonthlySalary_Rls { get; set; }
			public int DailySalary_Rls { get; set; }
			public int OverTime_Rls { get; set; }
			public int Delay_Rls { get; set; }
			public int NightWork_Rls { get; set; }
			public int HolidayWork_Rls { get; set; }
			public short OverTime_Min { get; set; }
			public short Delay_Min { get; set; }
			public short NightWork_Min { get; set; }
			public short HolidayWork_Min { get; set; }
			public int MaskanRls { get; set; }
			public int Olad_Rls { get; set; }
			public int Bon_Rls { get; set; }
			public long Bonus { get; set; }
			public long Advance { get; set; }
			public long Loan { get; set; }
			public long OtherAddition { get; set; }
			public long OtherDiscount { get; set; }
			public short DailyMission_Day { get; set; }
			public short HourlyMission_Min { get; set; }
			public int DailyMission_Rls { get; set; }
			public int HourlyMission_Rls { get; set; }
			public long TotalSalary { get; set; }
			public long TotalSalaryInsurable { get; set; }
			public long TotalSalaryTaxable { get; set; }
			public long TotalTaxable { get; set; }
			public int InsurableEmployer { get; set; }
			public int Insurable { get; set; }
			public int Tax { get; set; }
			public long Continuous { get; set; }
			public long NonContinuous { get; set; }
			public int Discount { get; set; }
			public long NetSalary { get; set; }
			public long Buy { get; set; }
			public short Rounding { get; set; }
			public int OverTime_Hour { get; set; }
			public int Delay_Hour { get; set; }
			public int NightWork_Hour { get; set; }
			public int HolidayWork_Hour { get; set; }
			public int HourlyMission_Hour { get; set; }
			public int PayeSanavat { get; set; }
			public long Eydi { get; set; }
			public long Sanavat { get; set; }
			public string Description { get; set; }
			public string Acc1 { get; set; }
			public string Acc3 { get; set; }
			public string RlsName { get; set; }
			public string Month { get; set; }
			public short Year { get; set; }
			public string Code_melli { get; set; }
			public string Name { get; set; }
			public string NameKargah { get; set; }
			public string VahedKhedmat { get; set; }
			public string CompanyName { get; set; }
			public int Paye_Sanavat { get; set; }
			public byte[] Photo { get; set; }

			
		}
		public class Loan : BaseEntity<int>
		{
			public int ID_Payroll { get; set; }
			public byte ID_LoanType { get; set; }
			public string LoanName { get; set; }
			public long Amount { get; set; }
			public bool ShowToInsuranceList { get; set; }

		}



	}
}
