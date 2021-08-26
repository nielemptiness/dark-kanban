using System.Collections.Generic;

namespace DarkKanban.Core.Database.Domain
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