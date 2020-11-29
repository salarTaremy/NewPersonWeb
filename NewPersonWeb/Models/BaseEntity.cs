using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class BaseEntity<Tkey>
    {
        public Tkey ID { get; set; }
    }
}
