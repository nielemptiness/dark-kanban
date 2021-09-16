using System;

namespace DarkKanban.Core.Contracts.Interfaces.Models
{
    public interface IIdentity
    {
        public Guid Id { get; set; }
    }
}