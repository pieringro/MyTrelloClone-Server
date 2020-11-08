using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IBoardRepository Board { get; }
        ITaskListRepository TaskList { get; }
        ITaskRepository Task { get; }

        void Save();
        Task SaveAsync();

    }
}
