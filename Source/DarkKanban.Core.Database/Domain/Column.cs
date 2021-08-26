
using System;
using System.Collections.Generic;

namespace DarkKanban.Core.Database.Domain
{
    public class Column : Entity
    {
        public Column()
        {
            Records = new HashSet<Record>();
        }
        
        public virtual ICollection<Record> Records { get; set; }
        public Guid BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}