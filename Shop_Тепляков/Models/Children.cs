using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }
        public int IdShop {  get; set; }

        public Children() { }

        public Children(int id, string name, int price, int age, int idShop) : base(id, name, price)
        {
            this.Age = age;
            IdShop = idShop;
        }
    }
}
