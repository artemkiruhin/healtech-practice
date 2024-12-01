using NLog;

namespace MauiApp1.Front.Services.Log
{
    public interface ILoggingService
    {
        void LogTrace(string message);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception? exception = null);
        void LogFatal(string message, Exception? exception = null);
    }

    public class NLogLoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public NLogLoggingService(string loggerName = "DefaultLogger")
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public void LogTrace(string message)
        {
            _logger.Trace(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }

        public void LogError(string message, Exception? exception = null)
        {
            if (exception == null)
            {
                _logger.Error(message);
            }
            else
            {
                _logger.Error(exception, message);
            }
        }

        public void LogFatal(string message, Exception? exception = null)
        {
            if (exception == null)
            {
                _logger.Fatal(message);
            }
            else
            {
                _logger.Fatal(exception, message);
            }
        }
    }
}
