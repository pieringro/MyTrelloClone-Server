using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTrelloClone.DataAccess;
using MyTrelloClone.DataAccess.Data.BoardData.Commands;
using MyTrelloClone.DataAccess.Data.BoardData.Queries;
using MyTrelloClone.DataAccess.Data.Repository.IRepository;

namespace MyTrelloClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            return new JsonResult(await _mediator.Send(new GetAllBoardsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return new JsonResult(await _mediator.Send(new GetBoardByIdQuery() { Id = id }));
        }

        [HttpGet("{id}/tasklists")]
        public async Task<ActionResult> GetTaskListsByBoardId(int id)
        {
            return new JsonResult(await _mediator.Send(new GetTaskListsByBoardIdQuery() { BoardId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditBoardCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBoardByIdCommand { Id = id }));
        }
    }
}
