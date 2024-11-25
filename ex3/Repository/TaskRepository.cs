
using ex3.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ex3.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBcontext _dbContext;

        public TaskRepository(TasksDBcontext dbContext)
        {
            _dbContext = dbContext;
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
