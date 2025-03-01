namespace Mission08Group4_7.Models
{
    public interface ITaskRepository
    {
        List<TaskClass> Tasks { get; }
        List<Categories> Categories { get; }

        public void AddTask(TaskClass task);
        public void UpdateTask(TaskClass task);
        public void DeleteTask(TaskClass task);

    }
}