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
    public class GetTaskListByIdQuery : IRequest<TaskList>
    {
        public int Id { get; set; }

        public class GetTaskListByIdQueryHandler : IRequestHandler<GetTaskListByIdQuery, TaskList>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetTaskListByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<TaskList> Handle(GetTaskListByIdQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.TaskList.GetByIdAsync(query.Id);
                if (boardList == null)
                {
                    return null;
                }
                return boardList;
            }
        }
    }
}