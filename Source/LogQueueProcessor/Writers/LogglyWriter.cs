using Loggly;

namespace LogQueueProcessor.Writers
{
    internal class LogglyWriter : ILogWriter
    {
        private readonly ILogglyClient logglyClient = new LogglyClient();

        public void Write(LogRow logRow)
        {
            var e = new LogglyEvent();
            e.Data.Add("eventDate", logRow.Date ?? "");
            e.Data.Add("level", logRow.Level ?? "");
            e.Data.Add("logger", logRow.Logger ?? "");
            e.Data.Add("message", logRow.Message ?? "");
            e.Data.Add("exception", logRow.Exception ?? "");
            logglyClient.Log(e);
        }
    }
}