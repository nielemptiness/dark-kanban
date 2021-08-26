using System;

namespace DarkKanban.Core.Database.Domain
{
    public class Record : Entity
    {
        public Guid ColumnId { get; set; }
        public virtual Column Column { get; set; }
    }
}