using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Contracts.Interfaces.Services;
using URF.Core.Abstractions;
using URF.Core.Services;

namespace DarkKanban.Core.Services.Record
{
    public class RecordService : Service<Contracts.Entities.Record>, IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public RecordService(IRecordRepository repository, IUnitOfWork unitOfWork) 
            : base(repository)
        {
            _recordRepository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}