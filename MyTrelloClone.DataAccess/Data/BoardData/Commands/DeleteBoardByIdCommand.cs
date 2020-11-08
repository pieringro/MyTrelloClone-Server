using MediatR;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;
using MyTrelloClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyTrelloClone.DataAccess.Data.BoardData.Commands
{
    public class DeleteBoardByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteBoardByIdCommandHandler : IRequestHandler<DeleteBoardByIdCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteBoardByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async System.Threading.Tasks.Task<int> Handle(DeleteBoardByIdCommand command, CancellationToken cancellationToken)
            {
                var board = await _unitOfWork.Board.GetByIdAsync(command.Id);
                if (board == null) return default;
                _unitOfWork.Board.Remove(board);
                await _unitOfWork.SaveAsync();
                return board.Id;
            }
        }
    }
}
