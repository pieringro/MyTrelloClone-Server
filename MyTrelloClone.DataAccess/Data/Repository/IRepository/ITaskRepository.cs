using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrelloClone.DataAccess.Data.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        System.Threading.Tasks.Task<Task> GetByIdAsync(int id);

        System.Threading.Tasks.Task<IEnumerable<Task>> GetTasksByTaskListIdAsync(int taskListId);

        System.Threading.Tasks.Task<int> UpdateAsync(Task task);
    }
}
