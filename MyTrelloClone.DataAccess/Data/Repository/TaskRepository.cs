using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrelloClone.DataAccess.Data.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task<Task> GetByIdAsync(int id)
        {
            return await GetFirstOrDefaultAsync(x => x.Id == id);
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByTaskListIdAsync(int taskListId)
        {
            return await GetAllAsync(x => x.TaskListId == taskListId);
        }

        public async System.Threading.Tasks.Task<int> UpdateAsync(Task task)
        {
            var objFromDb = await GetFirstOrDefaultAsync(x => x.Id == task.Id);

            if (objFromDb == null) return default;

            objFromDb.Name = task.Name;
            objFromDb.Description = task.Description;
            objFromDb.TaskListId = task.TaskListId;

            return await Context.SaveChangesAsync();
        }
    }
}
