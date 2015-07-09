using Loggly;

namespace LogQueueProcessor.Writers
{
    internal class LogglyWriter : ILogWriter
    {
        private readonly ILogglyClient logglyClient = new LogglyClient();

        public void Write(string message)
        {
            var e = new LogglyEvent();
            e.Data.Add("message", message);
            logglyClient.Log(e);
        }
    }
}