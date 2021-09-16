using System;
using System.Collections.Generic;
using DarkKanban.Core.Contracts.Enums;

namespace DarkKanban.Core.Contracts.Entities
{
    public class Column : Entity
    {
        public Column()
        {
            Records = new HashSet<Record>();
        }
        
        public virtual ICollection<Record> Records { get; set; }
        public Guid BoardId { get; set; }
        public ColumnType Type { get; set; }
        public virtual Board Board { get; set; }
    }
}