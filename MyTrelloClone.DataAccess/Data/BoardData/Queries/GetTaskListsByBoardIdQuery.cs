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
    public class GetTaskListsByBoardIdQuery : IRequest<IEnumerable<TaskList>>
    {
        public int BoardId { get; set; }

        public class GetTaskListByBoardIdQueryHandler : IRequestHandler<GetTaskListsByBoardIdQuery, IEnumerable<TaskList>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetTaskListByBoardIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<TaskList>> Handle(GetTaskListsByBoardIdQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.TaskList.GetAllTaskListByBoardId(query.BoardId);
                if (boardList == null)
                {
                    return null;
                }
                return boardList;
            }
        }
    }
}
