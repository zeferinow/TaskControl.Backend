using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class ProceedingDescriptionEntity : MongoEntity
    {
        public ObjectId TaskId { get; set; }
        public ObjectId ProceedingId { get; set; }
        public string DescriptionPlainText { get; set; }
    }
}
