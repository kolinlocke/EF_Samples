using EF_Sample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Sample
{
    internal class Repository_EF : IRepository
    {
        AdventureWorksContext _Cn;
        public Repository_EF(AdventureWorksContext Cn) {
            this._Cn = Cn;
            //this.Cn = new AdventureWorksContext();
        }

        public void Add<T_Model>(T_Model Obj) where T_Model : class
        {
            _Cn.Set<T_Model>().Add(Obj);
            _Cn.SaveChanges();
        }

        public void Dispose()
        {
            _Cn.Dispose();
        }
    }
}
