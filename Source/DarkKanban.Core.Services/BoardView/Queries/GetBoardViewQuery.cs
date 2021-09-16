using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Models;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using MediatR;

namespace DarkKanban.Core.Services.BoardView.Queries
{
    public class GetBoardViewQuery : IRequest<BoardModel>, IIdentity
    {
        public Guid Id { get; set; }
    }

    public class GetBoardViewQueryHandler : IRequestHandler<GetBoardViewQuery, BoardModel>
    {
        private readonly IBoardViewService _boardViewService;
        private readonly IMapper _mapper;

        public GetBoardViewQueryHandler(IBoardViewService boardViewService, IMapper mapper)
        {
            _boardViewService = boardViewService;
            _mapper = mapper;
        }

        public async Task<BoardModel> Handle(GetBoardViewQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardViewService.GetBoardView(request.Id, cancellationToken);

            if (board == null)
            {
                throw new ArgumentException("No such board!");
            }

            return _mapper.Map<BoardModel>(board);
        }
    }
}