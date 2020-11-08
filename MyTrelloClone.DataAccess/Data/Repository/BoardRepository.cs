using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.Repository
{
    public class BoardRepository: Repository<Board>, IBoardRepository
    {

        public BoardRepository(ApplicationContext context) : base(context)
        {

        }


        public async Task<Board> GetByIdAsync(int id)
        {
            return await GetFirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
