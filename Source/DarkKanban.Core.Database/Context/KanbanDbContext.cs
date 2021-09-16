using DarkKanban.Core.Contracts.Entities;
using DarkKanban.Core.Contracts.Interfaces.Database;
using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Database.Context
{
    public class KanbanDbContext : DbContext, IKanbanDbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options)
        {
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KanbanDbContext).Assembly);
        }

    }
}