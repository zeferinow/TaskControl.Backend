using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class TaskListEntity : TaskEntity
    {
        public ObjectId TaskId { get; set; }
        public string GeneratorName { get; set; }
        public string ResponsibleName { get; set; }
        public int NumberOfProceedings { get; set; }
        public IEnumerable<ObjectId> ProceedingGeneratorsIds { get; internal set; }
        public IEnumerable<DateTime> ProceedingsDates { get; internal set; }
        public DateTime? LastProceedingDate { get; internal set; }
    }
}
