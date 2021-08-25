using Microsoft.EntityFrameworkCore;

namespace DarkKanban.Core.Database.Context
{
    public class KanbanDbContext : DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KanbanDbContext).Assembly);
        }

    }
}