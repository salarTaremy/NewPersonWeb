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
        public Customer GetCustomerInfo(string Ssn)
        {
            var param = new DynamicParameters(new { Ssn = Ssn });
            Customer customer = db.GetList<Customer>("Web.GetCustomerInfo", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public TarafHesab GetTarafHesab(string Ssn)
        {
            var param = new DynamicParameters(new { Ssn = Ssn });
            TarafHesab tarafHesab = db.GetList<TarafHesab>("Web.GetTarafHesab", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (tarafHesab == null)
            {
                return null;
            }
            return tarafHesab;
        }

    }
}
