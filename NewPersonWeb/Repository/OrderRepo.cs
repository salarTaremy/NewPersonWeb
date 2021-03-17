using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Repository
{
    public class OrderRepo
    {

        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);


        public List<Order> GetList(string ssn)
        {
            var param = new DynamicParameters(new { ssn = ssn });
            return db.GetList<Order>("Web.GetOrderList", param, System.Data.CommandType.StoredProcedure);
        }



    }
}
