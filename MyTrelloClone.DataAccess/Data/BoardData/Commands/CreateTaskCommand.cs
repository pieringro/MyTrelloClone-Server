using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskListId { get; set; }

        public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
            {
                var task = new Task()
                {
                    Name = command.Name,
                    Description = command.Description,
                    TaskListId = command.TaskListId
                };
                _unitOfWork.Task.Add(task);
                await _unitOfWork.SaveAsync();
                return task.Id;
            }
        }
    }
}
