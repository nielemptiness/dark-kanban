using System;
using System.Threading.Tasks;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using DarkKanban.Core.Services.Board.Queries;
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

        [HttpGet]
        public async Task<ActionResult<GetBoardsResponse>> GetAllBoards()
        {
            var result = await _mediator.Send(new GetBoardsQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<ActionResult<BoardModel>> GetBoard([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetBoardQuery { Id = id }));
        }
    }
}