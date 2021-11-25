using System;
using Logger.Models;
using Logger.Services.Abstractions;

namespace Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly IConfigService _configService;
        private string _timeFormat;

        public LoggerService(IFileService fileService, IConfigService configService)
        {
            _fileService = fileService;
            _configService = configService;
            _timeFormat = _configService.LoggerConfig.TimeFormat;
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void Log(LogType logType, string log)
        {
            var message = $"{DateTime.UtcNow.ToString(_timeFormat)}: {logType}: {log}";
            Console.WriteLine(message);
            WriteLogToFile(message);
        }

        public void WriteLogToFile(string message)
        {
            _fileService.WriteToFile(message);
        }
    }
}