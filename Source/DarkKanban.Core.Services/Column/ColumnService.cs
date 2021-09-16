using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Contracts.Interfaces.Services;
using URF.Core.Abstractions;
using URF.Core.Services;

namespace DarkKanban.Core.Services.Column
{
    public class ColumnService : Service<Contracts.Entities.Column>, IColumnService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColumnRepository _columnRepository;
        
        public ColumnService(IColumnRepository columnRepository, IUnitOfWork unitOfWork) 
            : base(columnRepository)
        {
            _columnRepository = columnRepository;
            _unitOfWork = unitOfWork;
        }
    }
}