using DarkKanban.Core.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Contracts.Interfaces.Database
{
    public interface IKanbanDbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}