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
    public class GetAllTaskListQuery: IRequest<IEnumerable<TaskList>>
    {

        public class GetAllTaskListQueryHandler : IRequestHandler<GetAllTaskListQuery, IEnumerable<TaskList>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllTaskListQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<TaskList>> Handle(GetAllTaskListQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.TaskList.GetAllAsync();
                if (boardList == null)
                {
                    return null;
                }
                return boardList;
            }
        }
    }
}
