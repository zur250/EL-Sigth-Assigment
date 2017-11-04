using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost Host = new ServiceHost(typeof(EL_SigthServer.ServerImpl));
            Host.Open();
            Console.WriteLine("Host is successfully up");
            Console.ReadLine();
            Host.Close();
        }
    }
}
