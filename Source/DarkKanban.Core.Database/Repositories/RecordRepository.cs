using DarkKanban.Core.Contracts.Entities;
using DarkKanban.Core.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using URF.Core.EF.Trackable;

namespace DarkKanban.Core.Database.Repositories
{
    public class RecordRepository : TrackableRepository<Record>, IRecordRepository
    {
        public RecordRepository(DbContext context) : base(context)
        {
        }
    }
}