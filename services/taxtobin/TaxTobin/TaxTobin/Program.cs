using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TaxTobin
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseLinuxIfAvailable();
                x.Service<ServiceBase>(s =>
                {
                    s.ConstructUsing(name => new ServiceBase());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Tax tobin webservice for calculating stock tax");
                x.SetDisplayName("TaxTobin-Webservice");
                x.SetServiceName("TaxTobin-Webservice");
            });
        }
    }
}
