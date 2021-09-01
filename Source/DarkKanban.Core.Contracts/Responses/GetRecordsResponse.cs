using System.Collections.Generic;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Contracts.Responses
{
    public class GetRecordsResponse
    {
        public List<EntityShortInfoModel> Records { get; set; }
        public int RecordCount { get; set; }
    }
}