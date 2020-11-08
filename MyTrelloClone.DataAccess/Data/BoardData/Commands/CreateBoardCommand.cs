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
    public class CreateBoardCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateBoardCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateBoardCommand command, CancellationToken cancellationToken)
            {
                var board = new Board()
                {
                    Name = command.Name,
                    Description = command.Description
                };
                _unitOfWork.Board.Add(board);
                await _unitOfWork.SaveAsync();
                return board.Id;
            }
        }
    }
}
