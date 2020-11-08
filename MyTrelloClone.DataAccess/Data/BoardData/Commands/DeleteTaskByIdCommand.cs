using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class DeleteTaskByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteTaskByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(DeleteTaskByIdCommand command, CancellationToken cancellationToken)
            {
                var task = await _unitOfWork.Task.GetByIdAsync(command.Id);
                if (task == null) return default;
                _unitOfWork.Task.Remove(task);
                await _unitOfWork.SaveAsync();
                return task.Id;
            }
        }
    }
}
