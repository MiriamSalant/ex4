using ex3.Services.Logger;

namespace TasksApi.Services.Logger
{
    public class LoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoggerService GetLogger(int x)
        {
            if (x == 1)
                return _serviceProvider.GetRequiredService<FileLoggerService>();
            else if (x == 2)
                return _serviceProvider.GetRequiredService<ILoggerService>();
            else
                return _serviceProvider.GetRequiredService<DbLoggerService>();
        }
    }
}
