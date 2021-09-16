using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using DarkKanban.Core.Services.Board.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.Column.Queries
{
    public class GetColumnsQuery : IRequest<GetColumnsResponse>
    {
        public Guid BoardId { get; set; }
    }
    
    public class GetColumnsQueryHandler : IRequestHandler<GetColumnsQuery, GetColumnsResponse>
    {
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetColumnsQueryHandler(IColumnService columnService, IMapper mapper, IMediator mediator)
        {
            _columnService = columnService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GetColumnsResponse> Handle(GetColumnsQuery request, CancellationToken cancellationToken)
        {
            var board = await _mediator.Send(new GetBoardQuery { Id = request.BoardId }, cancellationToken);

            if (board == null)
            {
                throw new Exception($"No such board as {request.BoardId}");
            }

            var columns = await _columnService
                .Queryable()
                .Where(x => x.BoardId == request.BoardId)
                .ToListAsync(cancellationToken);

            return new GetColumnsResponse
            {
                Columns = _mapper.Map<List<EntityShortInfoModel>>(columns),
                ColumnCount = columns.Count
            };
        }
    }
}