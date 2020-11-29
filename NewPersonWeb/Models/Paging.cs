using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class Paging:BaseEntity<int>
    {
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public int CountInPage { get; set; } //9
        public int CurentPgae { get; set; }
        public string SortType { get; set; }    // 'Desc' or 'Asc'
        public int SortOrder { get; set; }    // Code Or Name or ...
    }
}
