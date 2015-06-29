namespace LogQueueProcessor.Writers
{
    internal interface ILogWriter
    {
        void Write(string message);
    }
}