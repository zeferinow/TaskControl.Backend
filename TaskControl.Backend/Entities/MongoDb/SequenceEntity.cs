using MongoDB.Bson;
using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class SequenceEntity : MongoEntity
    {
        public ESequenceType SequenceName { get; set; }
        public int SequenceValue { get; set; }
        public ObjectId? TaskId { get; set; }
    }
}
