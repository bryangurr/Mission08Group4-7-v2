
namespace Mission08Group4_7.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskDbContext _context;
        public EFTaskRepository(TaskDbContext temp)
        {
            _context = temp;
        }
        public List<TaskClass> Tasks => _context.Tasks.ToList();
        public List<Categories> Categories => _context.Categories.ToList();

        public void AddTask(TaskClass task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskClass task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
        
        public void DeleteTask(TaskClass task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }



    }
}
