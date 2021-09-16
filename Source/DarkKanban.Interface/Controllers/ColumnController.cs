using System;
using System.Threading;
using System.Threading.Tasks;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using DarkKanban.Core.Services.Column.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DarkKanban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColumnController : Controller
    {
        private readonly IMediator _mediator;

        public ColumnController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{boardId:guid}/columns")]
        public async Task<ActionResult<GetColumnsResponse>> GetAll([FromRoute] Guid boardId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetColumnsQuery { BoardId = boardId }, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{columnId:guid}")]
        public async Task<ActionResult<ColumnModel>> Get([FromRoute] Guid columnId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetColumnQuery { ColumnId = columnId }, cancellationToken);
        }
    }
}