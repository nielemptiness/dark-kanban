using System;
using DarkKanban.Core.Contracts.Interfaces.Models;

namespace DarkKanban.Core.Contracts.Models
{
    public class EntityShortInfoModel : IIdentity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}