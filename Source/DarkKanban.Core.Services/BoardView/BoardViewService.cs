using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DarkKanban.Core.Contracts.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Services.BoardView
{
    public class BoardViewService : IBoardViewService
    {
        private readonly IBoardService _boardService;

        public BoardViewService(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public async Task<Contracts.Entities.Board> GetBoardView(Guid id, CancellationToken cancellationToken)
        {
            var board = await _boardService
                .Queryable()
                .Include(x => x.Columns)
                .ThenInclude(x => x.Records)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return board;
        }
    }
}