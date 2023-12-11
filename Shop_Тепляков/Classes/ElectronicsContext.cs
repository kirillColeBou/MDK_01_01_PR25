using Shop_Тепляков.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Classes
{
    public class ElectronicsContext : Electronics, Interfaces.IContext
    {
        public ElectronicsContext() { }

        public ElectronicsContext(int Id, string Name, int Price, int Capacity, int Drivingspeed, int IdShop, string Src) : base(Id, Name, Price, Capacity, Drivingspeed, IdShop, Src) { }

        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allElectronics = new List<object>();
            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader electronicsData = Common.DBConnection.Query("SELECT * FROM [Электроника]", connection);
            while (electronicsData.Read())
            {
                ShopContext shopElement = allShop.Find(x => (x as ShopContext).Id == electronicsData.GetInt32(3)) as ShopContext;
                ElectronicsContext newElectronics = new ElectronicsContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,
                    electronicsData.GetInt32(1),
                    electronicsData.GetInt32(2),
                    electronicsData.GetInt32(3),
                    electronicsData.GetString(4));
                allElectronics.Add(newElectronics);
            }
            Common.DBConnection.CloseConnection(connection);
            return allElectronics;
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
