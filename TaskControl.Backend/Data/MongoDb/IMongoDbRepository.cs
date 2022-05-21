using MongoDB.Driver;
using System;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.MongoDb
{
    public interface IMongoDbRepository<T> : IMongoRepositoryCommand<T>, IMongoRepositoryQueryable<T>, IDisposable
        where T : MongoEntity
    {
        IMongoCollection<T> Collection { get; }
        void ValidateAndThrow(T obj);
    }
}
