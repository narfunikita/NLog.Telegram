using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Telegram.Demo
{
    public class Program
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
            Console.ReadLine();
        }
    }
}