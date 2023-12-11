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

        public Electronics(string name, int price, int capacity, int drivingspeed) : base(name, price)
        {
            this.Capacity = capacity;
            this.drivingSpeed = drivingspeed;
        }
    }
}
