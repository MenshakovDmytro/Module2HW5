using System;
using Logger.Services.Abstractions;

namespace Logger.Helper
{
    public class App
    {
        private readonly IActionsService _actions;
        private readonly ILoggerService _loggerService;

        public App(IActionsService actions, ILoggerService loggerService)
        {
            _actions = actions;
            _loggerService = loggerService;
        }

        public void StartWork()
        {
            var random = new Random();
            bool result;
            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (random.Next(1, 4))
                    {
                        case 1:
                            result = _actions.WriteInfoLog();
                            break;
                        case 2:
                            result = _actions.SkipLogic();
                            break;
                        case 3:
                            result = _actions.BreakLogic();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _loggerService.LogWarning($"Action got this custom exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _loggerService.LogError($"Action failed by a reason: {ex}");
                }
            }
        }
    }
}