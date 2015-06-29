using System;
using System.Configuration;
using System.IO;
using System.Messaging;
using LogQueueProcessor.Writers;

namespace LogQueueProcessor.Processors
{
    public class MsmqProcessor : BaseProcessor
    {
        private const int BatchSize = 100;

        private MessageQueue queue;
        private readonly TimeSpan receiveTimeout = TimeSpan.FromSeconds(5);
        private ILogWriter writer;

        protected override void Initialize()
        {
            queue = new MessageQueue(ConfigurationManager.AppSettings["LogQueueName"]);
            writer = new LogentriesWriter();
        }

        protected override void DoIteration()
        {
            for (var i = 0; i < BatchSize; i++)
            {
                try
                {
                    var message = queue.Receive(receiveTimeout);
                    if (message == null)
                    {
                        return;
                    }

                    using (var reader = new StreamReader(message.BodyStream))
                    {
                        var body = reader.ReadToEnd();
                        writer.Write(body);
                    }
                }
                catch (MessageQueueException ex)
                {
                    if (ex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    {
                        return;
                    }
                    throw;
                }
            }
        }
    }
}
