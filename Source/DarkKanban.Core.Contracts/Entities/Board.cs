using System.Collections.Generic;

namespace DarkKanban.Core.Contracts.Entities
{
    public class Board : Entity
    {
        public Board()
        {
            Columns = new HashSet<Column>();
        }
        public virtual ICollection<Column> Columns { get; set; }
    }
}