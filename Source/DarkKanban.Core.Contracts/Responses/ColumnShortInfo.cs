using DarkKanban.Core.Contracts.Enums;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Contracts.Responses
{
    public class ColumnShortInfo : EntityShortInfoModel
    {
        public ColumnType Type { get; set; }
    }
}