namespace DarkKanban.Core.Contracts.Interfaces
{
    public interface IKanbanObject : IIdentity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}