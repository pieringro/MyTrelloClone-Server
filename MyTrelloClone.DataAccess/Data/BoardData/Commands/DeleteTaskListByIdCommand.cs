using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class DeleteTaskListByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteTaskListByIdCommandHandler : IRequestHandler<DeleteTaskListByIdCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteTaskListByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(DeleteTaskListByIdCommand command, CancellationToken cancellationToken)
            {
                var taskList = await _unitOfWork.TaskList.GetByIdAsync(command.Id);
                if (taskList == null) return default;
                _unitOfWork.TaskList.Remove(taskList);
                await _unitOfWork.SaveAsync();
                return taskList.Id;
            }
        }
    }
}
