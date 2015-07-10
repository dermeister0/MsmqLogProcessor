using LogentriesCore.Net;

namespace LogQueueProcessor.Writers
{
    internal class LogentriesWriter : ILogWriter
    {
        private readonly AsyncLogger asyncLogger = new AsyncLogger();

        public void Write(LogRow logRow)
        {
            asyncLogger.AddLine(logRow.RawMessage);
        }
    }
}