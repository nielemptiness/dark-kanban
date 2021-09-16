using System;
using DarkKanban.Core.Contracts.Interfaces.Models;

namespace DarkKanban.Core.Contracts.Responses
{
    public class GetBoardResponse : IKanbanObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ColumnShortInfo[] Columns { get; set; }
    }
}