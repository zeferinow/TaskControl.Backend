using MongoDB.Bson;
using System;
using System.Collections.Generic;
using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class TaskEntity : MongoEntity
    {
        public int SequenceNumber { get; set; }
        public string Title { get; set; } 
        public ObjectId? DescriptionId { get; set; }
        public ObjectId GeneratorId { get; set; }
        public ObjectId? ResponsibleId { get; set; }
        public ETaskStatus Status { get; set; }
        public DateTime OpeningDate { get; set; }
        public IEnumerable<ObjectId> ProceedingsIds { get; set; }
    }
}
