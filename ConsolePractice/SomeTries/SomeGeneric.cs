using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.SomeTries
{
    public static class SomeGeneric
    {
        public static void Execute()
        {
            var loggerTxt = new LoggerService<LogTxt>();
            var loggerSql = new LoggerService<LogSql>();
            var loggerMongoDb = new LoggerService<LogMongoDB>();

            var message = "Error 205";

            loggerTxt.ExecuteLogging(message);
            loggerSql.ExecuteLogging(message);
            loggerMongoDb.ExecuteLogging(message);

            Console.WriteLine();
            Console.WriteLine();

            var logToAllServices = new LoggerForAllServices();

            logToAllServices.LogForEachService("Error 205");
        }
    }

    public class LoggerService<TLogger> where TLogger : ILogger, new()
    {
        TLogger _logger { get; }

        public LoggerService()
        {
            _logger = new TLogger();
        }

        public void ExecuteLogging(string message)
        {
            _logger.LogMessage(message);
        }
    }

    public class LoggerForAllServices
    {
        List<ILogger> _loggers { get; } = new List<ILogger>();
        public LoggerForAllServices()
        {
            _loggers.Add(new LogTxt());
            _loggers.Add(new LogSql());
            _loggers.Add(new LogMongoDB());
        }

        public void LogForEachService(string message)
        {
            foreach(var logger in _loggers)
            {
                logger.LogMessage(message);
            }
        }
    }

    public interface ILogger
    {
        void LogMessage(string message);
    }

    public class LogTxt : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Log into txt: {message}");
        }
    }

    public class LogSql : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Log into sql: {message}");
        }
    }

    public class LogMongoDB : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Log into mongoDB: {message}");
        }
    }
}
