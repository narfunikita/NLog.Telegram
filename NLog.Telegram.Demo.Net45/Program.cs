using System;

namespace NLog.Telegram.Demo.Net45
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            try
            {
                throw new ApplicationException("Any Exception");
            }
            catch (Exception ex)
            {
                _logger.Error("TestException", ex);
            }

            Console.WriteLine("Done. check chat");
            Console.ReadKey(true);
        }
    }
}
