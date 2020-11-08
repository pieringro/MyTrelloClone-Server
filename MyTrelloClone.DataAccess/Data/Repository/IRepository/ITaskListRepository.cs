using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository.IRepository
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        Task<TaskList> GetByIdAsync(int id);

        Task<IEnumerable<TaskList>> GetAllTaskListByBoardId(int boardId);
    }
}
