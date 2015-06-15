using System;
using NLog;

namespace TestSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ex = new ArgumentException("args are wrong.");
            LogManager.GetCurrentClassLogger().Error(ex, "Only test. Съешь же ещё этих мягких французских булок да выпей чаю.");
        }
    }
}