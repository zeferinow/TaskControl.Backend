using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class ProceedingEntity : MongoEntity
    {
        public int SequenceNumber { get; set; }
        public ObjectId TaskId { get; set; }
        public DateTime Date { get; set; }
        public ObjectId GeneratorId { get; set; }
        public ObjectId DescriptionId { get; set; }
    }
}
