using LogentriesCore.Net;

namespace LogQueueProcessor.Writers
{
    internal class LogentriesWriter : ILogWriter
    {
        private readonly AsyncLogger asyncLogger = new AsyncLogger();

        public void Write(string message)
        {
            asyncLogger.AddLine(message);
        }
    }
}