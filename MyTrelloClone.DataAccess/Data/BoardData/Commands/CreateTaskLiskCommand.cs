using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class CreateTaskLiskCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BoardId { get; set; }

        public class CreateTaskLiskCommandHandler : IRequestHandler<CreateTaskLiskCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateTaskLiskCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateTaskLiskCommand command, CancellationToken cancellationToken)
            {
                var taskList = new TaskList()
                {
                    Name = command.Name,
                    Description = command.Description,
                    BoardId = command.BoardId,
                };
                _unitOfWork.TaskList.Add(taskList);
                await _unitOfWork.SaveAsync();
                return taskList.Id;
            }
        }
    }
}
