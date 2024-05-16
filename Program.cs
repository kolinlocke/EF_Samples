using EF_Sample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EF_Sample
{
    internal class Program
    {
        static ServiceProvider SvcProvider { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Setup_DataConnection();
            Test_02();

        }

        static void Setup_DataConnection()
        {
            var Services = new ServiceCollection();
            Services
                .AddSingleton<IManager, Manager_AWS>()
                .AddSingleton<IRepository, Repository_EF>()            
                .AddDbContextPool<AdventureWorksContext>(
                    new Action<IServiceProvider, DbContextOptionsBuilder>(
                        (O_Provider, O_Options) => {
                            var Manager = O_Provider.GetRequiredService<IManager>();
                            var ConnectionString = Manager.Get_ConnectionString();

                            O_Options.UseSqlServer(ConnectionString);
                            
                            }));

            SvcProvider = Services.BuildServiceProvider();

        }

        static void Test_02()
        {
            var Repo =  SvcProvider.GetRequiredService<IRepository>();
            Repo.Add(new Customer());

             //var Svc =  SvcProvider.GetSe
            
        }

        static void Test_01()
        {
            Program Prg = new Program();

            Customer Cust = new Customer();
            Cust.FirstName = "Marvin Mas Pogi 2";
            Cust.LastName = "Maniwala Ka Pre TALAGA";
            Cust.PasswordHash = "1";
            Cust.PasswordSalt = "1";


            AdventureWorksContext Cn = new AdventureWorksContext();
            //Prg.AddObj<Customer>(Cust, Cn);

            Cn.Add(Cust);
            Cn.SaveChanges();

            Customer Cust2 = new Customer();
            Cust2.CustomerID = Cust.CustomerID;
            Cust2.FirstName = "Updated ni Marvin";
            Cust2.LastName = "Updated ni Marvin2";
            Cust2.PasswordHash = "1";
            Cust2.PasswordSalt = "1";
            Cust2.ModifiedDate = DateTime.Now;

            Cn.Update(Cust2);
            Cn.SaveChanges();


            /*
            using (Repository_EF Repo = new Repository_EF())
            {
                Repo.Add(Cust);
            }
            */
        }

        public void AddObj<T_Model>(T_Model Obj, DbContext Cn) where T_Model : class
        {
            Cn.Set<T_Model>().Add(Obj);
            Cn.SaveChanges();
        }
    }
}
