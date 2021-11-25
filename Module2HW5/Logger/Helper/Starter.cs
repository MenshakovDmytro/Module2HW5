using Logger.Helper;
using Logger.Providers;
using Logger.Providers.Abstractions;
using Logger.Services;
using Logger.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Logger
{
    public class Starter
    {
        public void Run()
        {
            var start = new ServiceCollection()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IStreamControlService, StreamControlService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IFileConversionService, JsonConversionService>()
                .AddTransient<IActionsService, ActionsService>()
                .AddTransient<App>()
                .BuildServiceProvider();
            var app = start.GetService<App>();
            app.StartWork();
            start.Dispose();
        }
    }
}