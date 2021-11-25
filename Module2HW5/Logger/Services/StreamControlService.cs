using System;
using System.IO;
using Logger.Services.Abstractions;

namespace Logger.Services
{
    public class StreamControlService : IStreamControlService, IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public StreamControlService(string path)
        {
            _streamWriter = new StreamWriter(path, true) { AutoFlush = true };
        }

        ~StreamControlService()
        {
            Dispose();
        }

        public void WriteData(string data)
        {
            _streamWriter.WriteLine(data);
        }

        public void Dispose()
        {
            _streamWriter.Close();
            _streamWriter.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}