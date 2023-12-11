using Shop_Тепляков.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Classes
{
    public class ChildrenContext : Children, Interfaces.IContext
    {
        public ChildrenContext() { }

        public ChildrenContext(int Id, string Name, int Price, int Age, int IdShop, string Src) : base(Id, Name, Price, Age, IdShop, Src) { }

        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allChildren = new List<object>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader childrenData = Common.DBConnection.Query("SELECT * FROM [Детские товары]", connection);
            while (childrenData.Read())
            {
                ShopContext shopElement = allShop.Find(x => (x as ShopContext).Id == childrenData.GetInt32(2)) as ShopContext;
                ChildrenContext newChildren = new ChildrenContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,
                    childrenData.GetInt32(1),
                    childrenData.GetInt32(2),
                    childrenData.GetString(3));
                allChildren.Add(newChildren);
            }
            Common.DBConnection.CloseConnection(connection);
            return allChildren;
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
