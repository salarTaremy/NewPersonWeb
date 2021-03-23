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
    public class EmploymentRepo
    {
        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);
        private Data.Dal db_person = new Data.Dal(Data.DataBase.Person);

        public EmploymentOrder GetEmploymentOrder( string Ssn)
        {
            var param = new DynamicParameters(new { Ssn = Ssn });
            var EmpOrd = db.GetList<EmploymentOrder>("Web.GetEmploymentOrder", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (EmpOrd == null)
            {
                return null;
            }
            return EmpOrd;
        }

        public List<Payroll> GetPayrollList(string Ssn)
        {
            var param = new DynamicParameters(new { Ssn = Ssn });
            var Lst = db.GetList<Payroll>("Web.UspGetPayrolls", param, System.Data.CommandType.StoredProcedure);
            if (Lst == null)
            {
                return null;
            }
            return Lst;
        }

        public PayrollViewModel GetPayrollDetail(int ID)
        {
            PayrollViewModel PVM = new PayrollViewModel();

            // Begin Create Datatable
            var Dt = new DataTable();
            Dt.Columns.Add(new DataColumn { ColumnName = "Value", DataType = typeof(int) });
            var dr = Dt.NewRow();
            dr["Value"] = ID;
            Dt.Rows.Add(dr);
            // End Create Datatable


            //var param = new DynamicParameters(
            //    new
            //    {
            //        ssn = Ssn,
            //        sortOrder = shop.paging.SortOrder,
            //        countInPage = shop.paging.CountInPage,
            //        curentPgae = shop.paging.CurentPgae,
            //        keyword = shop.Filter.Keyword,
            //        GroupID = GroupID,
            //        brands = DtBr
            //    });

            string SpName = "[Sl].[UspGetPayroll]";
            using (var con = new SqlConnection(db_person.GetConnectionString()))
            {
                var Result = con.QueryMultiple(SpName, null, commandType: CommandType.StoredProcedure);
                shop.Products = Result.Read<Product>().ToList();
                shop.paging = Result.Read<Paging>().FirstOrDefault();
                shop.Filter.Brands = Result.Read<ProductBrand>().ToList();
                shop.Filter.Groups = Result.Read<ProductGroup>().ToList();
            }

            return PVM;
        }



     


    }
}
