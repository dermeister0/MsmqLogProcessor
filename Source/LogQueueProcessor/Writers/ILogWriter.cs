namespace LogQueueProcessor.Writers
{
    internal interface ILogWriter
    {
        void Write(LogRow logRow);
    }
}