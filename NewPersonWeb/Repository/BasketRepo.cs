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
    public class BasketRepo
    {

        private Data.Dal db = new Data.Dal(Data.DataBase.AvandP);

        public Basket GetBasket(string Ssn)
        {
            var param = new DynamicParameters(new { ssn = Ssn });
            Basket basket = db.GetList<Basket>("Web.GetBasket", param, System.Data.CommandType.StoredProcedure).FirstOrDefault();
            if (basket == null)
            {
                return null;
            }

            basket.Details = GetBasketDetail(basket.ID);
            return basket;
        }

        public List<BasketDetail> GetBasketDetail(int ID_Basket)
        {
            var param = new DynamicParameters(new { ID_Basket = ID_Basket });
            return db.GetList<BasketDetail>("Web.GetBasketDetail", param, System.Data.CommandType.StoredProcedure);
        }

        public BasketDetail GetBasketDetailIfExistsProduct(string Ssn, long ID_Product)
        {
            BasketDetail basketDetail = null;
            string SpName = "Web.GetBasketDetailIfExistsProduct";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ID_Product = ID_Product
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                basketDetail = con.Query<BasketDetail>(SpName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return basketDetail;
        }

        public List<Product> GetListOfBasketProducts(string Ssn)
        {
            var param = new DynamicParameters(
                new { ssn = Ssn });
            return db.GetList<Product>("Web.GetListOfBasketProducts", param, System.Data.CommandType.StoredProcedure);
        }

        public BuyHistory GetBuyHistory(string Ssn, long ProductID)
        {
            BuyHistory result = null;
            string SpName = "Web.[GetBuyHistory]";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn,
                    ID_Product = ProductID
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                result = con.Query<BuyHistory>(SpName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return result;
        }

        public bool ChangeQty(string Ssn, long ID_Product, short Qty)
        {
            int affectedRows;
            string SpName = "Web.ChangeQtyProductInBasket";
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


        public bool RemoveProductFromBasket(string Ssn, long ID_Product)
        {
            int affectedRows;
            string SpName = "Web.RemoveProductFromBasket";
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


        public bool ConfirmBasket(string Ssn)
        {
            int affectedRows;
            string SpName = "Web.ConfirmBasket";
            var param = new DynamicParameters(
                new
                {
                    Ssn = Ssn
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }



        public bool ConfirmBasket(int Id_Basket)
        {
            int affectedRows;
            string SpName = "Web.ConfirmBasket";
            var param = new DynamicParameters(
                new
                {
                    Id_Basket = Id_Basket
                });
            using (var con = new SqlConnection(db.GetConnectionString()))
            {
                affectedRows = con.Execute(SpName, param, commandType: CommandType.StoredProcedure);
            }
            return (affectedRows != 0);
        }


    }
}
