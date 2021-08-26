using System;

namespace DarkKanban.Core.Database.Helpers
{
    public class TableInsertConfig
    {
        public string TableName { get; set; }
        public string[] Columns { get; set; }
        public object[] Values { get; set; }

        public Guid? EntityId { get; set; }
    }
}