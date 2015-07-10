namespace LogQueueProcessor
{
    public class LogRow
    {
        public LogRow(string rawMessage)
        {
            RawMessage = rawMessage;

            if (string.IsNullOrEmpty(rawMessage))
                return;

            var values = rawMessage.Split('|');

            if (values.Length == 5)
            {
                Date = values[0];
                Level = values[1];
                Logger = values[2];
                Message = values[3];
                Exception = values[4];
            }
            else
            {
                Message = rawMessage;
            }
        }

        public string RawMessage { get; private set; }
        public string Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}