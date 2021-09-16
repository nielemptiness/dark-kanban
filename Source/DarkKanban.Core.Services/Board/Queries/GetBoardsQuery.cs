using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.Board.Queries
{
    public class GetBoardsQuery : IRequest<GetBoardsResponse>
    {
    }
    
    public class GetBoardsQueryHandler : IRequestHandler<GetBoardsQuery, GetBoardsResponse>
    {
        private readonly IBoardService _boardService;
        private readonly IMapper _mapper;

        public GetBoardsQueryHandler(IMapper mapper, IBoardService boardService)
        {
            _mapper = mapper;
            _boardService = boardService;
        }

        public async Task<GetBoardsResponse> Handle(GetBoardsQuery request, CancellationToken cancellationToken)
        {
            var boards =  await _boardService.Queryable().ToListAsync(cancellationToken);

            return new GetBoardsResponse
            {
                Boards = _mapper.Map<List<EntityShortInfoModel>>(boards),
                TotalCount = boards.Count
            };
        }
    }
}