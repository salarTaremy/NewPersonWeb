using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class ApiResult : BaseEntity<int>
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}