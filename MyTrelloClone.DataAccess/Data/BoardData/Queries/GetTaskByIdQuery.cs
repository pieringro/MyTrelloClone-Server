using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Queries
{
    public class GetTaskByIdQuery : IRequest<Task>
    {
        public int Id { get; set; }

        public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Task>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<Task> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
            {
                var boardList = await _unitOfWork.Task.GetByIdAsync(query.Id);
                if (boardList == null)
                {
                    return null;
                }
                return boardList;
            }
        }
    }
}