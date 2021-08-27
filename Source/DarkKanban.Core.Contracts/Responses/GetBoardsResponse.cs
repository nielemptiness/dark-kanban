using System.Collections.Generic;
using DarkKanban.Core.Contracts.Models;

namespace DarkKanban.Core.Contracts.Responses
{
    public class GetBoardsResponse
    {
        public List<EntityShortInfoModel> Boards { get; set; }
        public int TotalCount { get; set; }
    }
}