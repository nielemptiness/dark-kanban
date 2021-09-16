using System;
using System.Linq;
using DarkKanban.Core.Contracts.Entities;
using DarkKanban.Core.Contracts.Enums;
using EnumsNET;

namespace DarkKanban.Core.Database.Helpers
{

    public static class ColumnsInitHelper
    {
        public static TableInsertConfig[] CreateDefaultColumns(Guid boardId)
        {
            return Enum.GetValues(typeof(ColumnType))
                .Cast<ColumnType>()
                .Where(result => result != ColumnType.Undefined &&  result != ColumnType.Custom)
                .Select(val =>
                {
                    var id = Guid.NewGuid();
                    return new TableInsertConfig
                    {
                        TableName = nameof(Column), 
                        Columns = new[] { "Id", "Name", "Description", "Type", "BoardId" },
                        Values = new object[] { id, GetEnumDesc(val), "Default column. You can change the layout in settings", (int)val, boardId },
                        EntityId = id
                    };
                }).ToArray();
        }
        
        private static string GetEnumDesc(ColumnType value)
        {
            var description = value.AsString(EnumFormat.Description);
            return description;
        }

    }
}