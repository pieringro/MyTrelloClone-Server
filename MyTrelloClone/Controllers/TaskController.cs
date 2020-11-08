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
    public class TaskController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return new JsonResult(await _mediator.Send(new GetAllTaskQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return new JsonResult(await _mediator.Send(new GetTaskByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditTaskCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteTaskByIdCommand { Id = id }));
        }
    }
}
