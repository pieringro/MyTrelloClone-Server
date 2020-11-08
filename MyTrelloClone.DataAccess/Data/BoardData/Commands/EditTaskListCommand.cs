using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class EditTaskListCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BoardId { get; set; }

        public class EditTaskListCommandHandler : IRequestHandler<EditTaskListCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public EditTaskListCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(EditTaskListCommand command, CancellationToken cancellationToken)
            {
                var objFromDb = await _unitOfWork.TaskList.GetFirstOrDefaultAsync(x => x.Id == command.Id);
                if (objFromDb == null) return default;

                objFromDb.Name = command.Name;
                objFromDb.Description = command.Description;
                objFromDb.BoardId = command.BoardId;

                await _unitOfWork.SaveAsync();

                return objFromDb.Id;
            }
        }
    }
}
