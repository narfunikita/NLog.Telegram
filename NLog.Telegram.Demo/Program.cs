using NLog.Config;
using NLog.Targets;

namespace NLog.Telegram.Demo
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            ConfigureNLog();

            _logger.Trace("Trace message");
            _logger.Debug("Debug message");
            _logger.Info("Info message");
            _logger.Warn("Warn message");
            _logger.Error("Error message");
        }

        private static void ConfigureNLog()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}"
            };

            var telegramTarget = new TelegramTarget
            {
                BotToken = "xxx",
                ChatId = "xxx",
                Layout = @"[${logger}] ${message}"
            };

            config.AddTarget("console", consoleTarget);
            config.AddTarget("telegram", telegramTarget);

            // Step 3. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            var rule2 = new LoggingRule("*", LogLevel.Trace, telegramTarget);

            config.LoggingRules.Add(rule1);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
        }
    }
}
