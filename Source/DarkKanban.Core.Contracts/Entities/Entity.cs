﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DarkKanban.Core.Contracts.Interfaces.Models;

namespace DarkKanban.Core.Contracts.Entities
{
    public class Entity : URF.Core.EF.Trackable.Entity, IKanbanObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}