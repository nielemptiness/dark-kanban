using System.Collections.Generic;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Contracts.Responses
{
    public class GetColumnsResponse
    {
        public List<EntityShortInfoModel> Columns { get; set; }
        public int ColumnCount { get; set; }
    }
}