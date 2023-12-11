using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Models
{
    public class Sport : Shop
    {
        public string Size { get; set; }
        public int IdShop {  get; set; }
        public string Src {  get; set; }
        public Sport() { }

        public Sport(int id, string name, int price, string size, int idShop, string src) : base(id, name, price)
        {
            this.Size = size;
            this.IdShop = idShop;
            this.Src = src;
        }
    }
}
