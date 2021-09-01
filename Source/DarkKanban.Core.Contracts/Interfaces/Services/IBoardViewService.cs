using System;
using System.Threading;
using System.Threading.Tasks;
using DarkKanban.Core.Contracts.Entities;

namespace DarkKanban.Core.Contracts.Interfaces.Services
{
    public interface IBoardViewService
    {
        Task<Board> GetBoardView(Guid id, CancellationToken cancellationToken);
    }
}