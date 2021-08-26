using System;
using DarkKanban.Core.Contracts.Enums;
using DarkKanban.Core.Contracts.Interfaces;

namespace DarkKanban.Core.Contracts.Models
{
    public class ColumnModel : IKanbanObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ColumnType Type { get; set; }
        public RecordModel[] Items { get; set; }
    }
}