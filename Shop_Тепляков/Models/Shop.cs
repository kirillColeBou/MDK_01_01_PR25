using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Models
{
    public class Shop
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Shop(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
