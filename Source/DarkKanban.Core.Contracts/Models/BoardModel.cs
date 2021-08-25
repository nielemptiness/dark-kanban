using System;

namespace DarkKanban.Core.Contracts.Models
{
    public class BoardModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ColumnModel[] Columns { get; set; }
    }
}