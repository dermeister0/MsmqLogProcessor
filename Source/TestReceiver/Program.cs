using System;
using System.Configuration;
using System.IO;
using System.Messaging;

namespace TestReceiver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var queue = new MessageQueue(ConfigurationManager.AppSettings["QueueName"]);

            for (var i = 0; i < 10; i++)
            {
                try
                {
                    var message = queue.Receive(TimeSpan.FromSeconds(5));
                    if (message == null)
                        continue;

                    using (var reader = new StreamReader(message.BodyStream))
                    {
                        var body = reader.ReadToEnd();
                        Console.WriteLine(body);
                    }
                }
                catch (MessageQueueException ex)
                {
                    if (ex.MessageQueueErrorCode != MessageQueueErrorCode.IOTimeout)
                        throw;
                }
            }
        }
    }
}