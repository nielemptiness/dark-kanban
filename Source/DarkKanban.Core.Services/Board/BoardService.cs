using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Contracts.Interfaces.Services;
using URF.Core.Abstractions;
using URF.Core.Services;

namespace DarkKanban.Core.Services.Board
{
    public class BoardService :  Service<Contracts.Entities.Board>, IBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;
        
        public BoardService(IBoardRepository boardRepository, IUnitOfWork unitOfWork) 
            : base(boardRepository)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }
    }
}