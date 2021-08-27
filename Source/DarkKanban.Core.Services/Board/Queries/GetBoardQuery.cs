using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Models;
using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.Board.Queries
{
    public class GetBoardQuery : IRequest<BoardModel>, IIdentity
    {
        public Guid Id { get; set; }
    }
    
    public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, BoardModel>
    {
        private readonly IBoardService _boardService;
        private readonly IMapper _mapper;

        public GetBoardQueryHandler(IMapper mapper, IBoardService boardService)
        {
            _mapper = mapper;
            _boardService = boardService;
        }

        public async Task<BoardModel> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardService
                .Queryable()
                .Include(b => b.Columns)
                .Where(b => b.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<BoardModel>(board);
        }
    }
}