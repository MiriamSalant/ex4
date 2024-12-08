using ex3.Models;
using ex3.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TasksApi.Services.Logger;

namespace ex3.Services.Logger
{
    public class DbLoggerService : ILoggerService
    {
        private readonly LoggerRepository _loggerRepository;

        public DbLoggerService(LoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public void Log(string message)
        {
            try
            {
                _loggerRepository.logIntoDB(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to log message: {ex.Message}");
            }
        }
    }
}
