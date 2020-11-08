using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Board = new BoardRepository(_context);
            TaskList = new TaskListRepository(_context);
            Task = new TaskRepository(_context);
        }

        public IBoardRepository Board { get; }

        public ITaskListRepository TaskList { get; }

        public ITaskRepository Task { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
