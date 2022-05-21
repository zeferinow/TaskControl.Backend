using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class TaskDescriptionEntity : MongoEntity
    {
        public ObjectId TaskId { get; set; }
        public string DescriptionPlainText { get; set; }
    }
}
