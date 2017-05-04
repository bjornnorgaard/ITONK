using log4net;
using log4net.Config;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxTobin.NancyModules;
using Topshelf.Logging;

namespace TaxTobin
{
    public class ServiceBase
    {
        private NancyHost m_nancyHost;

        public void Start()
        {
            SetupLogging();
            
            m_nancyHost = new NancyHost(new Uri("http://localhost:5000"));
            m_nancyHost.Start();
        }

        public void Stop()
        {
            m_nancyHost.Stop();
        }

        private void SetupLogging()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(GetLogFilePath()));

            log4net.Util.SystemInfo.NullText = "";

            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Info("Starting Tax Tobin service");
            log.Info("Logging initialised");
        }

        private string GetLogFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Log4NetConfileName);
        }

        private string Log4NetConfileName { get; } = "log4net.config";
    }
}
