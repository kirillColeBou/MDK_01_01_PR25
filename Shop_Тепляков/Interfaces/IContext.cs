using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Тепляков.Interfaces
{
    public interface IContext
    {
        List<object> All();
        void Save(bool Update = false);
        void Delete();
    }
}
