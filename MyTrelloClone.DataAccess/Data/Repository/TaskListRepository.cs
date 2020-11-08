using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository
{
    public class TaskListRepository : Repository<TaskList>, ITaskListRepository
    {
        public TaskListRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<TaskList> GetByIdAsync(int id)
        {
            return await GetFirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<TaskList>> GetAllTaskListByBoardId(int boardId)
        {
            return await GetAllAsync(x => x.BoardId == boardId);
        }
    }
}
