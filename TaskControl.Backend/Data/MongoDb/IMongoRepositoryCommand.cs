using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskControl.Backend.Data.MongoDb
{
    public interface IMongoRepositoryCommand<T> where T : class
    {
        T Add(IClientSessionHandle session, T entity);
        T Add(T entity);
        T Update(IClientSessionHandle session, T entity);
        T Update(T entity);
        Task DeleteAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<DeleteResult> DeleteAsync(IClientSessionHandle session, ObjectId id, CancellationToken cancellationToken = default);
        Task<DeleteResult> DeleteAsync(ObjectId id, CancellationToken cancellationToken = default);
        Task<ReplaceOneResult> UpdateAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default);
        Task<ReplaceOneResult> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> AddAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(IClientSessionHandle session, ObjectId id);
        void Delete(IClientSessionHandle session, T entity);
        void Delete(ObjectId id);
        void Delete(T entity);
        void DeleteAll(IClientSessionHandle session);
    }
}
