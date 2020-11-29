using Dapper;
using NewPersonWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Repository
{
    public class ProductRepo
    {
        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);

        public List<Product> GetAll()
        {
            return db.GetList<Product>("Web.GetProductListPerSsnCode", null, System.Data.CommandType.StoredProcedure);
        }

        public List<Product> GetAll(string Ssn, int SortOrder = 0, int CountInPage = 15, int CurentPgae = 1)
        {
            var param = new DynamicParameters(
                new
                {
                    ssn = Ssn,
                    sortOrder = SortOrder,
                    countInPage = CountInPage,
                    curentPgae = CurentPgae
                });
            return db.GetList<Product>("Web.GetProductListPerSsnCode", param, System.Data.CommandType.StoredProcedure);
        }

        public List<Product> GetRelated(string Ssn, long ProductId = 15, int MaxCount = 1000)
        {
            var param = new DynamicParameters(
                new
                {
                    ssn = Ssn,
                    productId = ProductId,
                    maxCount = MaxCount
                });
            return db.GetList<Product>("[Web].[GetRelatedProduct]", param, System.Data.CommandType.StoredProcedure);
        }

        public List<ProductBrand> GetBrands(string Ssn)
        {
            var param = new DynamicParameters(new { ssn = Ssn });
            return db.GetList<ProductBrand>("Web.GetProductBrand", param, System.Data.CommandType.StoredProcedure);
        }

        public List<ProductGroup> GetGroups(string Ssn)
        {
            var param = new DynamicParameters(new { ssn = Ssn });
            return db.GetList<ProductGroup>("Web.GetProductGroup", param, System.Data.CommandType.StoredProcedure);
        }
    }
}