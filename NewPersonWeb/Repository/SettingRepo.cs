using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Repository
{
    public class SettingRepo
    {

        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);
        public Setting GetGetSettings(int ID)
        {
            var param = new DynamicParameters(new { ID = ID });
            Setting setting = db.GetList<Setting>("Web.GetSettings", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (setting == null)
            {
                return null;
            }
            return setting;
        }


    }
}
