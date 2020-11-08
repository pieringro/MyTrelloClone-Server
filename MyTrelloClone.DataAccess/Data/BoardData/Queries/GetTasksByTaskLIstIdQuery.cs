using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Queries
{
    public class GetTasksByTaskListIdQuery : IRequest<IEnumerable<Task>>
    {
        public int TaskListId { get; set; }

        public class GetTasksByTaskListIdQueryHandler : IRequestHandler<GetTasksByTaskListIdQuery, IEnumerable<Task>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetTasksByTaskListIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<IEnumerable<Task>> Handle(GetTasksByTaskListIdQuery query, CancellationToken cancellationToken)
            {
                var tasks = await _unitOfWork.Task.GetTasksByTaskListIdAsync(query.TaskListId);
                if (tasks == null)
                {
                    return null;
                }
                return tasks;
            }
        }
    }
}
