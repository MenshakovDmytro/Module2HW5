using System.IO;
using Logger.Models;

namespace Logger.Services.Abstractions
{
    public interface IStreamControlService
    {
        public void WriteData(string data);
    }
}