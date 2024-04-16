using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Sample
{
    internal interface IRepository : IDisposable
    {
        void Add<T_Model>(T_Model Obj) where T_Model : class;
    }
}
