using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Repository
{
    public class CustomerRepo
    {
        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);
        public Customer GetCustomer(string Ssn)
        {
            var param = new DynamicParameters(new { Ssn = Ssn });
            Customer customer = db.GetList<Customer>("Web.GetCustomer", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
    }
}
