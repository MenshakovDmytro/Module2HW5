using System;
using System.Collections;
using System.IO;
using Logger.Helper;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class FileService : IFileService
    {
        private const int DirectoryCapacity = 3;
        private readonly IStreamControlService _streamControlService;
        private readonly IConfigService _configService;
        private readonly IComparer _comparer;
        private string _filePath;

        public FileService(IConfigService configService)
        {
            _configService = configService;
            _comparer = new FileComparer();
            Init();
            _streamControlService = new StreamControlService(_filePath);
        }

        public void WriteToFile(string data)
        {
            _streamControlService.WriteData(data);
        }

        public void CreateDirectory(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        public void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        public void RemoveExcessFiles(string path)
        {
            var files = Directory.GetFiles(path);
            if (files.Length >= DirectoryCapacity)
            {
                Array.Sort(files, _comparer);
                for (var i = 0; i < files.Length - DirectoryCapacity; i++)
                {
                    File.Delete(files[i]);
                }
            }
        }

        private void Init()
        {
            var directoryPath = _configService.LoggerConfig.DirectoryPath;
            var fileName = DateTime.UtcNow.ToString(_configService.LoggerConfig.FileName);
            var fileExtension = _configService.LoggerConfig.FileExtension;
            var file = $"{fileName}{fileExtension}";
            _filePath = $"{Directory.GetCurrentDirectory()}{directoryPath}{file}";
            CreateDirectory(directoryPath);
            CreateFile(_filePath);
            RemoveExcessFiles(directoryPath);
        }
    }
}