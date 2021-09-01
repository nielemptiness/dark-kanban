using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Contracts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.Column.Queries
{
    public class GetColumnQuery : IRequest<ColumnModel>
    {
        public Guid ColumnId { get; set; }
    }
    
    public class GetColumnQueryHandler : IRequestHandler<GetColumnQuery, ColumnModel>
    {
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;

        public GetColumnQueryHandler(IColumnService columnService, IMapper mapper)
        {
            _columnService = columnService;
            _mapper = mapper;
        }

        public async Task<ColumnModel> Handle(GetColumnQuery request, CancellationToken cancellationToken)
        {
            var result = await _columnService.Queryable()
                .Where(x=>x.Id == request.ColumnId).FirstOrDefaultAsync(cancellationToken);

            if (result == null) throw new ArgumentException($"No such column as {request.ColumnId}");
            
            return _mapper.Map<ColumnModel>(result);
        }
    }
}