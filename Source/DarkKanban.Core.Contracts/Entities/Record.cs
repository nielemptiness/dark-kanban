using System;

namespace DarkKanban.Core.Contracts.Entities
{
    public class Record : Entity
    {
        public Guid ColumnId { get; set; }
        public virtual Column Column { get; set; }
    }
}