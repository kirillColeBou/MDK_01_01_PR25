using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Models
{
    public class Electronics : Shop
    {
        public int Capacity { get; set; }
        public int drivingSpeed { get; set; }
        public int IdShop {  get; set; }

        public Electronics() { }

        public Electronics(int id, string name, int price, int capacity, int drivingspeed, int idShop) : base(id, name, price)
        {
            this.Capacity = capacity;
            this.drivingSpeed = drivingspeed;
            IdShop = idShop;
        }
    }
}
