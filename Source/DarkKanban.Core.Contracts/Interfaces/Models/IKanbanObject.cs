namespace DarkKanban.Core.Contracts.Interfaces.Models
{
    public interface IKanbanObject : IIdentity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}