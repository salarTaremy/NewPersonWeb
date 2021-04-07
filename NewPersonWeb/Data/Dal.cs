using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Data
{


    public enum DataBase { AvandP,Person };
    public class Dal
    {

        private DataBase db;
        private String Ip = "192.168.200.220";
        private String DbAvandP = "AvandP00";
        private String DbPerson = "Personnel";
        private String User = "sa";
        private String Password = "Ba2015th2";
        private String AppName = "PersonWeb";

        public Dal(DataBase dataBase)
        {
            this.db = dataBase;
        }
        public string GetConnectionString()
        {
            if (this.db == DataBase.AvandP)
            {
                return $"Data Source={Ip};Initial Catalog ={DbAvandP};Persist Security Info=True;User ID={User};Password={Password};Application Name={AppName} ";
            }
            else 
            {
                return $"Data Source={Ip};Initial Catalog ={DbPerson};Persist Security Info=True;User ID={User};Password={Password};Application Name={AppName} ";
            }
        }



        public int Execute(string sql, object param)
        {
            using (var con = new SqlConnection(GetConnectionString()))
            {
                var Result = con.Execute(sql, param);
                return Result;
            }
        }
        public List<TEntity> GetList<TEntity>(string SpName, DynamicParameters param, CommandType? commandType = null)
        {
            //var param = new DynamicParameters(new { CARID = 66, CARNAME = "Volvo" });
            using (var con = new SqlConnection(GetConnectionString()))
            {
                var Result = con.Query<TEntity>(SpName, param, commandType: CommandType.StoredProcedure).ToList();
                return Result;
            }
        }
        //public List<IEnumerable<object>> GetList(string SpName, DynamicParameters? param, CommandType? commandType = null,  int ObjectCount=0)
        //{
        //    List<IEnumerable<object>> Lst = new List<IEnumerable<object>>();
        //    using (var con = new SqlConnection(GetConnectionString()))
        //    {
        //        var Result = con.QueryMultiple(SpName, param, commandType: CommandType.StoredProcedure);
        //        for (int i = 0; i < ObjectCount; i++)
        //        {
        //            Lst.Add(Result.Read());
        //        }

        //        return Lst;
        //    }
        //}




    }
}
