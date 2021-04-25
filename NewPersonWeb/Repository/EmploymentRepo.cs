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
            

            // Begin Create Datatable
            var Dt = new DataTable();
            Dt.Columns.Add(new DataColumn { ColumnName = "Value", DataType = typeof(int) });
            var dr = Dt.NewRow();
            dr["Value"] = ID;
            Dt.Rows.Add(dr);
            // End Create Datatable


            var param = new DynamicParameters(
                new
                {
                    ID_Array = Dt
                });

            PayrollViewModel PVM = new PayrollViewModel();
            string SpName = "[Sl].[UspGetPayroll]";
            using (var con = new SqlConnection(db_person.GetConnectionString()))
            {
                var Result = con.QueryMultiple(SpName, param, commandType: CommandType.StoredProcedure);
                PVM.IncParams = Result.Read<PayrollViewModel.parameter>().ToList();
                PVM.DecParams = Result.Read<PayrollViewModel.parameter>().ToList();
                PVM.header = Result.Read<PayrollViewModel.Header>().FirstOrDefault();
                PVM.Details = Result.Read<PayrollViewModel.Detail>().ToList();
                PVM.Loans = Result.Read<PayrollViewModel.Loan>().ToList();
            }

            return PVM;
        }



     


    }
}
