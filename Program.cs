using NLog;
using ShapesTask.Shapes;
using System.Diagnostics;

namespace ShapesTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();

            LogManager.Configuration = LoggingConfigBuilder.GetConsoleConfiguration(@"${message}");

            string inputFilePath;
            try
            {
                inputFilePath = args[0];
                if (args.Length > 1)
                {
                    LogManager.Configuration = LoggingConfigBuilder.GetFileConfiguration(args[1], @"${message}");
                }
            }
            catch
            {
                string process = Process.GetCurrentProcess().ProcessName;
                logger.Error("Использование:" +
                    $"\n\t{process} <input_file_path> <output_file_path>" +
                    $"\n\t{process} <input_file_path>");
                return;
            }

            try
            {
                Shape shape = ShapeParser.Parse(inputFilePath);
                logger.Info(shape);
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка парсинга: {ex.Message}");
            }
        }
    }
}