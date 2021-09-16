using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using DarkKanban.Core.Contracts.Responses;
using DarkKanban.Core.Services.Column.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.Record.Queries
{
    public class GetRecordsQuery : IRequest<GetRecordsResponse>
    {
        public Guid ColumnId { get; set; }
    }
    
    public class GetRecordsQueryHandler : IRequestHandler<GetRecordsQuery, GetRecordsResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRecordService _recordService;
        private readonly IMapper _mapper;

        public GetRecordsQueryHandler(IMediator mediator, IRecordService recordService, IMapper mapper)
        {
            _mediator = mediator;
            _recordService = recordService;
            _mapper = mapper;
        }

        public async Task<GetRecordsResponse> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
        {
            var column = await _mediator.Send(new GetColumnQuery { ColumnId = request.ColumnId }, cancellationToken);

            if (column == null)
            {
                throw new ArgumentException("No such column!");
            }

            var items = await _recordService
                .Queryable()
                .Where(x => x.ColumnId == request.ColumnId)
                .ToListAsync(cancellationToken);
            
            if (items == null || items.Count == 0)
            {
                throw new Exception($"Column {request.ColumnId} does not have any records!");
            }

            return new GetRecordsResponse
            {
                Records = _mapper.Map<List<EntityShortInfoModel>>(items),
                RecordCount = items.Count
            };
        }
    }
}