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
    public class ShopRepo
    {
        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);

        public Shop GetPage(string Ssn, Shop shop)
        {
            int GroupID = 0;
            if (shop.Filter.Groups.Count > 0)
            {
                GroupID = shop.Filter.Groups.FirstOrDefault().ID;
            }
            var DtBr = new DataTable();
            DtBr.Columns.Add(new DataColumn { ColumnName = "Value", DataType = typeof(int) });
            foreach (var item in shop.Filter.Brands)
            {
                var dr = DtBr.NewRow();
                dr["Value"] = item.ID;
                DtBr.Rows.Add(dr);
            }

            string SpName = "Web.GetProductListPerSsnCode";
            var param = new DynamicParameters(
                new
                {
                    ssn = Ssn,
                    sortOrder = shop.paging.SortOrder,
                    countInPage = shop.paging.CountInPage,
                    curentPgae = shop.paging.CurentPgae,
                    keyword = shop.Filter.Keyword,
                    GroupID = GroupID,
                    brands = DtBr
                });

            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                var Result = con.QueryMultiple(SpName, param, commandType: CommandType.StoredProcedure);
                shop.Products = Result.Read<Product>().ToList();
                shop.paging = Result.Read<Paging>().FirstOrDefault();
                shop.Filter.Brands = Result.Read<ProductBrand>().ToList();
                shop.Filter.Groups = Result.Read<ProductGroup>().ToList();
            }

            return shop;
        }

        public bool AddProductToBasket(string Ssn, long ID_Product, short Qty)
        {
            int affectedRows;
            string SpName = "Web.AddProductToBasket";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ID_Product = ID_Product,
                    Qty = Qty
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }

        public bool AddProductToFavorite(string Ssn, long ID_Product)
        {
            int affectedRows;
            string SpName = "Web.[AddProductToFavorite]";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ID_Product = ID_Product
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }

        public bool RemoveProductFromeFavorite(string Ssn, long ID_Product)
        {
            int affectedRows;
            string SpName = "Web.[RemoveProductFromFavorite]";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ID_Product = ID_Product
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }

        public Product GetProduct(string Ssn, long ProductID)
        {
            Product product = null;
            string SpName = "Web.[GetProductDetail]";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ProductID = ProductID
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                product = con.Query<Product>(SpName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return product;
        }


  

    }
}