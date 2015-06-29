namespace LogQueueProcessor.Processors
{
    public enum ProcessorStatus
    {
        On,
        PendingOff,
        Off
    }

    internal interface IProcessor
    {
        ProcessorStatus Status { get; }
        void Start(object argument);
        void Stop();
    }
}