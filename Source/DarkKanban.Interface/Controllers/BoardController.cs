using System;
using System.Threading;
using System.Threading.Tasks;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using DarkKanban.Core.Services.Board.Queries;
using DarkKanban.Core.Services.BoardView.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DarkKanban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private readonly IMediator _mediator;

        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

         [HttpGet("view/{id:guid}")]
         public async Task<ActionResult<BoardModel>> GetBoardView([FromRoute] Guid id, CancellationToken cancellationToken)
         {
             var result = await _mediator.Send(new GetBoardViewQuery { Id = id }, cancellationToken);

             return result;
         }


        [HttpGet]
        public async Task<ActionResult<GetBoardsResponse>> GetAllBoards(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBoardsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetBoardResponse>> GetBoard([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetBoardQuery { Id = id }, cancellationToken));
        }
    }
}