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
    public class GetBoardByIdQuery : IRequest<Board>
    {
        public int Id { get; set; }

        public class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, Board>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetBoardByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Board> Handle(GetBoardByIdQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.Board.GetByIdAsync(query.Id);
                return boardList;
            }
        }
    }
}
