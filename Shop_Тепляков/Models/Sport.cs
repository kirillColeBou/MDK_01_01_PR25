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

        public Sport(string name, int price, string size) : base(name, price)
        {
            this.Size = size;
        }
    }
}
