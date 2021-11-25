using Logger.Models;

namespace Logger.Services.Abstractions
{
    public interface IFileConversionService
    {
        public Config ConvertJsonToConfig(string jsonConfig);
    }
}