using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.BoardData.Queries
{
    public class GetAllBoardsQuery : IRequest<IEnumerable<Board>>
    {

        public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, IEnumerable<Board>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBoardsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<Board>> Handle(GetAllBoardsQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.Board.GetAllAsync();
                if (boardList == null)
                {
                    return null;
                }
                return boardList;
            }
        }
    }
}
