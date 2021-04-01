using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace Voyage_Guide_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(Voyage_Guide.Voyage_Guide_Services)))
            {
                host.Open();
                Console.WriteLine("Host Started at :" + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
