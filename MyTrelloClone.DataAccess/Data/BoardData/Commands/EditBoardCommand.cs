using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class EditBoardCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class EditBoardCommandHandler : IRequestHandler<EditBoardCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public EditBoardCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(EditBoardCommand command, CancellationToken cancellationToken)
            {
                var objFromDb = await _unitOfWork.Board.GetFirstOrDefaultAsync(x => x.Id == command.Id);
                if (objFromDb == null) return default;

                objFromDb.Name = command.Name;
                objFromDb.Description = command.Description;

                await _unitOfWork.SaveAsync();

                return objFromDb.Id;
            }
        }
    }
}
