using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class Payroll : BaseEntity<int>
    {

        public string MonthName { get; set; }
        public string StatusName { get; set; }
        public short Year { get; set; }
        public long NetSalary { get; set; }

    }
}
