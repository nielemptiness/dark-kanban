namespace DarkKanban.Core.Contracts.Interfaces.Database
{
    public interface IKanbanDbContextFactory
    {
        IKanbanDbContext CreateKanbanDbContext();
    }
}