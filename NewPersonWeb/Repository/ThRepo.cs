using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Repository
{
    public class ThRepo
    {
        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);

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


        public bool ChangeThPass(string Ssn, string newPass)
        {
            int affectedRows;
            string SpName = "Web.ChangeThPass";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    newPass = newPass
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }


        public bool IsValidPerson(string Ssn)
        {
            bool result = false;
            int affectedRows;
            string SpName = "Web.IsValidPerson";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
     
                result = con.ExecuteScalar<bool>(SpName, param, commandType: CommandType.StoredProcedure);
                
            }
            return result;
        }



    }
}
