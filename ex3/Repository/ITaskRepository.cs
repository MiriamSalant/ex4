using ex3.Models;

namespace ex3.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<Tasks> GetTasks();

        Tasks CreateTask(Tasks task);

        void UpdateTask(Tasks task);

        void DeleteTask(int id);

        IEnumerable<Tasks> getTasksUser(int id);
    }
}
