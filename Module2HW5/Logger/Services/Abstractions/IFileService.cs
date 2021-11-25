using System.Collections;

namespace Logger.Services.Abstractions
{
    public interface IFileService
    {
        public void WriteToFile(string data);
        public void CreateDirectory(string directoryName);
        public void CreateFile(string fileName);
        public void RemoveExcessFiles(string path);
    }
}