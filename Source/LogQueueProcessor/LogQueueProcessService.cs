using System.ServiceProcess;
using LogQueueProcessor.Processors;

namespace LogQueueProcessor
{
    public partial class LogQueueProcessService : ServiceBase
    {
        private IProcessor msmqProcessor;

        public LogQueueProcessService()
        {
            InitializeComponent();
        }

        public void StartService()
        {
            msmqProcessor = new MsmqProcessor();
            msmqProcessor.Start(null);            
        }

        protected override void OnStart(string[] args)
        {
            StartService();
        }

        public void StopService()
        {
            if (msmqProcessor != null)
            {
                msmqProcessor.Stop();
            }            
        }

        protected override void OnStop()
        {
            StopService();
        }
    }
}