using EF_Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Program Prg = new Program();

            Customer Cust = new Customer();
            Cust.FirstName = "Marvin Mas Pogi 2";
            Cust.LastName = "Maniwala Ka Pre TALAGA";
            Cust.PasswordHash = "1";
            Cust.PasswordSalt = "1";

            //AdventureWorksContext Cn = new AdventureWorksContext();
            //Prg.AddObj<Customer>(Cust, Cn);

            using (Repository_EF Repo = new Repository_EF())
            {
                Repo.Add(Cust);
            }
        }

        public void AddObj<T_Model>(T_Model Obj, DbContext Cn) where T_Model : class
        {
            Cn.Set<T_Model>().Add(Obj);
            Cn.SaveChanges();
        }
    }
}
