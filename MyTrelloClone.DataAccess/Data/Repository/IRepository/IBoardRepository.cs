using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository.IRepository
{
    public interface IBoardRepository: IRepository<Board>
    {
        Task<Board> GetByIdAsync(int id);
    }
}
