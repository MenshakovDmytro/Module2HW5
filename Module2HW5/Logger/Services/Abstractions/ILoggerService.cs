using Logger.Models;

namespace Logger.Services.Abstractions
{
    public interface ILoggerService
    {
        public void LogError(string message);
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void Log(LogType logType, string log);
        public void WriteLogToFile(string message);
    }
}