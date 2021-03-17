using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class Order: BaseEntity<long>
    {
        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        [Display(Name = "مبلغ درخواست")]
        public int OrderRls { get; set; }
            
        [Display(Name = "مبلغ فاکتور")]
        public int FactorRls { get; set; }

    }
}
