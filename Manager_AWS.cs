using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Sample
{
    interface IManager
    {
        public String Get_Config();
        public String Get_ConnectionString();


    }

    internal class Manager_AWS : IManager
    {

        public String Get_Config()
        {
            return "DEV";
        }

        public string Get_ConnectionString()
        {
            var Config = this.Get_Config();

            //Get Config from App.Settings for ENVIRONMENT Settings (DEV,PROD,TEST)

            return "FROM AWS SECRET";
        }
    }
}
