using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace MyTrelloClone.DataAccess.Data.BoardData.Queries
{
    public class GetAllTaskQuery: IRequest<IEnumerable<Task>>
    {

        public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<Task>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllTaskQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<IEnumerable<Task>> Handle(GetAllTaskQuery query, CancellationToken cancellationToken)
            {
                var task = await _unitOfWork.Task.GetAllAsync();
                if (task == null)
                {
                    return null;
                }
                return task;
            }
        }
    }
}
