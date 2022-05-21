using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using TaskControl.Backend.Domain.Pagination;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class MongoEntity : Pageable, IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
