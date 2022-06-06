using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Domain.Enums;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class SequenceRepository : ISequenceRepository
    {
        public Lazy<IMongoDbRepository<SequenceEntity>> SequenceRepositoryInternal { get; set; }

        public int GetSequenceValue(ESequenceType sequenceType)
        {
            var filter = Builders<SequenceEntity>.Filter.Eq(s => s.SequenceName, sequenceType);
            var update = Builders<SequenceEntity>.Update.Inc(s => s.SequenceValue, 1);

            var result = SequenceRepositoryInternal.Value.Collection.FindOneAndUpdate(filter, update,
                new FindOneAndUpdateOptions<SequenceEntity, SequenceEntity> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

            return result.SequenceValue;
        }

        public int GetSequenceValue(ESequenceType sequenceType, ObjectId taskId)
        {
            var filter = Builders<SequenceEntity>.Filter.Eq(s => s.SequenceName, sequenceType) & Builders<SequenceEntity>.Filter.Eq(s => s.TaskId, taskId);
            var update = Builders<SequenceEntity>.Update.Inc(s => s.SequenceValue, 1);

            var result = SequenceRepositoryInternal.Value.Collection.FindOneAndUpdate(filter, update,
                new FindOneAndUpdateOptions<SequenceEntity, SequenceEntity> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

            return result.SequenceValue;
        }
    }
}
