using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Domain;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : MongoEntity
    {
        public Lazy<MongoDbContext> Context { get; set; }

        private IMongoCollection<T> collection;
        public IMongoCollection<T> Collection => collection ??= new MongoCollection<T>(Context.Value.GetCollection<T>());

        public void ValidateAndThrow(T obj)
        {
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(obj, new ValidationContext(obj), results, true))
            {
                throw new ValidationException(string.Join(' ', results.Select(result => result.ErrorMessage)));
            }
        }

        public T Add(T entity)
        {

            try
            {
                Collection.InsertOne(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await Collection.InsertOneAsync(entity, null, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void Delete(T entity)
        {
            try
            {
                Collection.DeleteOne(entityToDelete => entityToDelete.Id == entity.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ObjectId id)
        {
            try
            {
                Collection.DeleteOne(entityToDelete => entityToDelete.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                return Collection.DeleteOneAsync(entityToDelete => entityToDelete.Id == entity.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<DeleteResult> DeleteAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            try
            {
                return Collection.DeleteOneAsync(entityToDelete => entityToDelete.Id == id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T entity)
        {
            var filter = BuildUpdateDefinition(entity);

            try
            {
                Collection.ReplaceOne(filter, entity, new ReplaceOptions
                {
                    BypassDocumentValidation = false,
                    Collation = Collation.Simple,
                    IsUpsert = false
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<ReplaceOneResult> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var filter = BuildUpdateDefinition(entity);

            try
            {
                return await Collection.ReplaceOneAsync(filter, entity, new ReplaceOptions
                {
                    BypassDocumentValidation = false,
                    Collation = Collation.Simple,
                    IsUpsert = false
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Add(IClientSessionHandle session, T entity)
        {
            try
            {
                Collection.InsertOne(session, entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<T> AddAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await Collection.InsertOneAsync(session, entity, null, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void Delete(IClientSessionHandle session, T entity)
        {
            try
            {
                Collection.DeleteOne(session, entityToDelete => entityToDelete.Id == entity.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAll(IClientSessionHandle session)
        {
            try
            {
                var filter = Builders<T>.Filter.Empty;

                Collection.DeleteMany(session, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IClientSessionHandle session, ObjectId id)
        {
            try
            {
                Collection.DeleteOne(session, entityToDelete => entityToDelete.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task DeleteAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                return Collection.DeleteOneAsync(session, entityToDelete => entityToDelete.Id == entity.Id, new DeleteOptions { Collation = Collation.Simple }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<DeleteResult> DeleteAsync(IClientSessionHandle session, ObjectId id, CancellationToken cancellationToken = default)
        {
            try
            {
                return Collection.DeleteOneAsync(session, entityToDelete => entityToDelete.Id == id, new DeleteOptions { Collation = Collation.Simple }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(IClientSessionHandle session, T entity)
        {
            var filter = BuildUpdateDefinition(entity, session);

            try
            {
                Collection.ReplaceOne(session, filter, entity, new ReplaceOptions
                {
                    BypassDocumentValidation = false,
                    Collation = Collation.Simple,
                    IsUpsert = false
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<ReplaceOneResult> UpdateAsync(IClientSessionHandle session, T entity, CancellationToken cancellationToken = default)
        {
            var filter = BuildUpdateDefinition(entity);

            try
            {
                return await Collection.ReplaceOneAsync(session, filter, entity, new ReplaceOptions
                {
                    BypassDocumentValidation = false,
                    Collation = Collation.Simple,
                    IsUpsert = false
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAll()
        {
            return Collection.AsQueryable();
        }

        public T GetById(ObjectId id)
        {
            var builder = Builders<T>.Filter;

            var filter = builder.Eq(entityToUpdate => entityToUpdate.Id, id);
            return Collection.Find(filter).SingleOrDefault();
        }

        public async Task<T> GetByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var builder = Builders<T>.Filter;

            var filter = builder.Eq(entityToUpdate => entityToUpdate.Id, id);
            var result = await Collection.FindAsync(filter, null, cancellationToken);
            return result.FirstOrDefault();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private FilterDefinition<T> BuildUpdateDefinition(T entity, IClientSessionHandle session = null)
        {
            var builder = Builders<T>.Filter;

            var filter = builder.Eq(entityToUpdate => entityToUpdate.Id, entity.Id);
            return filter;
        }

    }
}
