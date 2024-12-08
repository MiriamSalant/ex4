
using ex3.Models;
using Microsoft.Data.SqlClient;
using TasksApi.Services.Logger;

namespace ex3.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBcontext _dbContext;
        private TasksApi.Services.Logger.LoggerFactory _loggerFactory;
        private ILoggerService _loggerService;

        public TaskRepository(TasksDBcontext dbContext, TasksApi.Services.Logger.LoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public Tasks CreateTask(Tasks task)
        {
            if (task == null)
                return null;
            if (_dbContext.User.FirstOrDefault(x => x.Id == task.UserId) == null)
                throw new Exception("User not found");
            if (_dbContext.Project.FirstOrDefault(x => x.ProjectId == task.ProjectId) == null)
                throw new Exception("Project not found");
            _dbContext.Tasks.Add(task);
            _loggerService = _loggerFactory.GetLogger(3);
            _loggerService.Log("New Task created: id: " + task.Id + " creation date: " + DateTime.Now);
            return task;
        }

        public void UpdateTask(Tasks task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _dbContext.Tasks.Find(id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Tasks> getTasksUser(int userId)
        {
            IEnumerable<Tasks> tasks = _dbContext.Tasks.Where(y => y.UserId == userId).Select(t => t).ToList();
            if (tasks != null)
                return tasks;
            return null;
        }
    }
}
