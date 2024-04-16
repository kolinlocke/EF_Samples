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
        DbContext Cn;
        public Repository_EF() {
            this.Cn = new AdventureWorksContext();
        }

        public void Add<T_Model>(T_Model Obj) where T_Model : class
        {
            Cn.Set<T_Model>().Add(Obj);
            Cn.SaveChanges();
        }

        public void Dispose()
        {
            Cn.Dispose();
        }
    }
}
