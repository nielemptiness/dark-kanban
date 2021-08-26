using System;
using DarkKanban.Core.Contracts.Interfaces.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DarkKanban.Core.Database.Context
{
    public class KanbanDbContextFactory : IDesignTimeDbContextFactory<KanbanDbContext>, IKanbanDbContextFactory
    {
        private const string ConnectionStringName = "DbConfig__ConnectionString";

        private const string DefaultLocalConnection =
            "User ID =rootuser;Password=rootuser;Server=dark-kanban-postgreDb;Port=5432;Database=darkkanbandb;Integrated Security=true;Pooling=true;";
        
        public KanbanDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringName) ?? DefaultLocalConnection;
            
            return Create(connectionString);
        }

        private KanbanDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KanbanDbContext>();

            optionsBuilder.UseNpgsql(connectionString);

            return new KanbanDbContext(optionsBuilder.Options);
        }
        
        public IKanbanDbContext CreateKanbanDbContext()
        {
            return CreateDbContext(Array.Empty<string>());
        }
    }
}