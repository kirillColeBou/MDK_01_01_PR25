using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Shop() { }

        public Shop(int id, string name, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
