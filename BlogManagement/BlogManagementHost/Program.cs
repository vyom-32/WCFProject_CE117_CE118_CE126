using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace BlogManagementHost
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(BlogManagement.Service1);
            Uri http = new Uri("http://localhost:8080/Service1");
            ServiceHost host = new ServiceHost(t, http);
            host.Open();
            Console.WriteLine("host running");
            Console.ReadLine();
            host.Close();

        }
    }
}
