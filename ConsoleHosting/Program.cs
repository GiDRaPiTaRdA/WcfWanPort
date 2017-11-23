using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost selfHost = new ServiceHost(typeof(Service),new Uri("http://10.0.0.184:54508"));

            try
            {
              
                selfHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine(selfHost.BaseAddresses.First());
#if DEBUG
                Console.ReadLine();
#endif
                // Close the ServiceHostBase to shutdown the service.  
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
