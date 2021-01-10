using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class BuyHistory 
    {

        public long BuyQty { get; set; }
        public byte DayCount { get; set; }
        public short MaxPerDayCount { get; set; }
        public long RemainingQty { get; set; }

    }
}
