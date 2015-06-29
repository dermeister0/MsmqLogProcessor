using System.ServiceProcess;
using System.Windows.Forms;

namespace LogQueueProcessor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if !DEBUG
            ServiceBase[] servicesToRun = new ServiceBase[] 
            { 
                new LogQueueProcessService() 
            };
            ServiceBase.Run(servicesToRun);
#else
            var service = new LogQueueProcessService();
            service.StartService();
            MessageBox.Show("Click OK to close the service.");
            service.StopService();
#endif
        }
    }
}
