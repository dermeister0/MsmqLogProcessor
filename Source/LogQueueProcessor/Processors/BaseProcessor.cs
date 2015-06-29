using System;
using System.Threading;
using NLog;

namespace LogQueueProcessor.Processors
{
    public abstract class BaseProcessor : IProcessor
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();
        private Thread thread;
        public ProcessorStatus Status { get; protected set; }

        public void Start(object argument)
        {
            thread = new Thread(ProcessLoop);
            thread.Start();
        }

        public void Stop()
        {
            Status = ProcessorStatus.PendingOff;

            while (Status != ProcessorStatus.Off)
            {
                Thread.Sleep(1000);
            }
        }

        private void ProcessLoop()
        {
            while (Status == ProcessorStatus.On)
            {
                try
                {
                    DoIteration();
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
            Status = ProcessorStatus.Off;
        }

        protected abstract void Initialize();
        protected abstract void DoIteration();
    }
}