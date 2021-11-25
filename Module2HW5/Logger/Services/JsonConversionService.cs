using System.IO;
using Logger.Models;
using Logger.Services.Abstractions;
using Newtonsoft.Json;

namespace Logger.Services
{
    public class JsonConversionService : IFileConversionService
    {
        public Config ConvertJsonToConfig(string jsonConfig)
        {
            var configFile = File.ReadAllText(jsonConfig);
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }
    }
}