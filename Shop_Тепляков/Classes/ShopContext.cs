using Shop_Тепляков.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Classes
{
    public class ShopContext : Shop, Interfaces.IContext
    {
        public ShopContext() { }

        public ShopContext(int Id, string Name, int Price) : base(Id, Name, Price) { }

        public List<object> All()
        {
            List<object> allShop = new List<object>();
            OleDbConnection connection = Common.DBConnection.Connection();
            if (MainWindow.discountIsApply == false)
            {
                OleDbDataReader shopData = Common.DBConnection.Query("SELECT * FROM [Товар]", connection);
                while (shopData.Read())
                {
                    ShopContext newShop = new ShopContext(
                        shopData.GetInt32(0),
                        shopData.GetString(1),
                        shopData.GetInt32(2));
                    allShop.Add(newShop);
                }
            }
            else
            {
                OleDbDataReader shopData_discount = Common.DBConnection.Query("SELECT * FROM [Скидка]", connection);
                while (shopData_discount.Read())
                {
                    ShopContext newShop = new ShopContext(
                        shopData_discount.GetInt32(0),
                        shopData_discount.GetString(1),
                        shopData_discount.GetInt32(2));
                    allShop.Add(newShop);
                }
            }
            Common.DBConnection.CloseConnection(connection);
            return allShop;
        }

        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
