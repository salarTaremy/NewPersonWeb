using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class Setting: BaseEntity<int>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string StringValue { get; set; }
        public string Description { get; set; }
    }
}
