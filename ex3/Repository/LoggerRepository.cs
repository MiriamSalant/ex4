using ex3.Models;
using Microsoft.EntityFrameworkCore;
using TasksApi.Services.Logger;

namespace ex3.Repository
{
    public class LoggerRepository
    {
        private readonly TasksDBcontext _dbContext;

        public LoggerRepository(TasksDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void logIntoDB(string message)
        {
            Messages newMessage = new Messages();
            newMessage.Message = message;
            _dbContext.Messages.Add(newMessage);
            _dbContext.SaveChanges();
        }
    }
}
