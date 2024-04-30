using NLog.Config;
using NLog.Targets;

namespace ShapesTask
{
    public class LoggingConfigBuilder
    {
        public static LoggingConfiguration GetConsoleConfiguration(string layout)
        {
            var consoleTarget = new ConsoleTarget("Console")
            {
                Layout = layout,
            };
            return GetConfiguration(consoleTarget);
        }

        public static LoggingConfiguration GetFileConfiguration(string fileName, string layout)
        {
            var fileTarget = new FileTarget("File")
            {
                FileName = fileName,
                Layout = layout,
            };
            return GetConfiguration(fileTarget);
        }

        private static LoggingConfiguration GetConfiguration(Target target)
        {
            LoggingConfiguration configuration = new LoggingConfiguration();
            configuration.AddTarget(target);
            configuration.AddRuleForAllLevels(target);
            return configuration;
        }
    }
}