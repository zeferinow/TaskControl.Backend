using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;

namespace TaskControl.Backend.Data.Repositories
{
    public class MongoCollection<T> : IMongoCollection<T> where T : MongoEntity
    {
        private IMongoCollection<T> MongoCollectionBase { get; }

        public CollectionNamespace CollectionNamespace => MongoCollectionBase.CollectionNamespace;

        public IMongoDatabase Database => MongoCollectionBase.Database;

        public IBsonSerializer<T> DocumentSerializer => MongoCollectionBase.DocumentSerializer;

        public IMongoIndexManager<T> Indexes => MongoCollectionBase.Indexes;

        public MongoCollectionSettings Settings => MongoCollectionBase.Settings;

        public MongoCollection(IMongoCollection<T> mongoCollectionBase)
        {
            MongoCollectionBase = mongoCollectionBase;
        }

        public IAsyncCursor<TResult> Aggregate<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Aggregate(pipeline, options, cancellationToken);
        }

        public IAsyncCursor<TResult> Aggregate<TResult>(IClientSessionHandle session, PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Aggregate(session, pipeline, options, cancellationToken);
        }

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.AggregateAsync(pipeline, options, cancellationToken);
        }

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(IClientSessionHandle session, PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.AggregateAsync(session, pipeline, options, cancellationToken);
        }

        public BulkWriteResult<T> BulkWrite(IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.BulkWrite(requests, options, cancellationToken);
        }

        public BulkWriteResult<T> BulkWrite(IClientSessionHandle session, IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.BulkWrite(session, requests, options, cancellationToken);
        }

        public Task<BulkWriteResult<T>> BulkWriteAsync(IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.BulkWriteAsync(requests, options, cancellationToken);
        }

        public Task<BulkWriteResult<T>> BulkWriteAsync(IClientSessionHandle session, IEnumerable<WriteModel<T>> requests, BulkWriteOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.BulkWriteAsync(session, requests, options, cancellationToken);
        }

        [Obsolete]
        public long Count(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Count(filter, options, cancellationToken);
        }

        [Obsolete]
        public long Count(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Count(session, filter, options, cancellationToken);
        }

        [Obsolete]
        public Task<long> CountAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountAsync(filter, options, cancellationToken);
        }

        [Obsolete]
        public Task<long> CountAsync(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountAsync(session, filter, options, cancellationToken);
        }

        public long CountDocuments(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountDocuments(filter, options, cancellationToken);
        }

        public long CountDocuments(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountDocuments(session, filter, options, cancellationToken);
        }

        public Task<long> CountDocumentsAsync(FilterDefinition<T> filter, CountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountDocumentsAsync(filter, options, cancellationToken);
        }

        public Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<T> filter, CountOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.CountDocumentsAsync(session, filter, options, cancellationToken);
        }

        public DeleteResult DeleteMany(FilterDefinition<T> filter, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteMany(filter, cancellationToken);
        }

        public DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteMany(filter, options, cancellationToken);
        }

        public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteMany(session, filter, options, cancellationToken);
        }

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteManyAsync(filter, cancellationToken);
        }

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteManyAsync(filter, options, cancellationToken);
        }

        public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteManyAsync(session, filter, options, cancellationToken);
        }

        public DeleteResult DeleteOne(FilterDefinition<T> filter, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOne(filter, cancellationToken);
        }

        public DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOne(filter, options, cancellationToken);
        }

        public DeleteResult DeleteOne(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOne(session, filter, options, cancellationToken);
        }

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOneAsync(filter, cancellationToken);
        }

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> filter, DeleteOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOneAsync(filter, options, cancellationToken);
        }

        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, DeleteOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DeleteOneAsync(session, filter, options, cancellationToken);
        }

        public IAsyncCursor<TField> Distinct<TField>(FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Distinct(field, filter, options, cancellationToken);
        }

        public IAsyncCursor<TField> Distinct<TField>(IClientSessionHandle session, FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Distinct(session, field, filter, options, cancellationToken);
        }

        public Task<IAsyncCursor<TField>> DistinctAsync<TField>(FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DistinctAsync(field, filter, options, cancellationToken);
        }

        public Task<IAsyncCursor<TField>> DistinctAsync<TField>(IClientSessionHandle session, FieldDefinition<T, TField> field, FilterDefinition<T> filter, DistinctOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.DistinctAsync(session, field, filter, options, cancellationToken);
        }

        public long EstimatedDocumentCount(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.EstimatedDocumentCount(options, cancellationToken);
        }

        public Task<long> EstimatedDocumentCountAsync(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.EstimatedDocumentCountAsync(options, cancellationToken);
        }

        public IAsyncCursor<TProjection> FindSync<TProjection>(FilterDefinition<T> filter, FindOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindSync(filter, options, cancellationToken);
        }

        public IAsyncCursor<TProjection> FindSync<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindSync(session, filter, options, cancellationToken);
        }

        public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<T> filter, FindOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindAsync(filter, options, cancellationToken);
        }

        public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, FindOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindAsync(session, filter, options, cancellationToken);
        }

        public TProjection FindOneAndDelete<TProjection>(FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndDelete(filter, options, cancellationToken);
        }

        public TProjection FindOneAndDelete<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndDelete(session, filter, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndDeleteAsync<TProjection>(FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndDeleteAsync(filter, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndDeleteAsync<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, FindOneAndDeleteOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndDeleteAsync(session, filter, options, cancellationToken);
        }

        public TProjection FindOneAndReplace<TProjection>(FilterDefinition<T> filter, T replacement, FindOneAndReplaceOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndReplace(filter, replacement, options, cancellationToken);
        }

        public TProjection FindOneAndReplace<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, T replacement,
            FindOneAndReplaceOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndReplace(session, filter, replacement, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndReplaceAsync<TProjection>(FilterDefinition<T> filter, T replacement, FindOneAndReplaceOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndReplaceAsync(filter, replacement, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndReplaceAsync<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, T replacement,
            FindOneAndReplaceOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.FindOneAndReplaceAsync(session, filter, replacement, options, cancellationToken);
        }

        public TProjection FindOneAndUpdate<TProjection>(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.FindOneAndUpdate(filter, update, options, cancellationToken);
        }

        public TProjection FindOneAndUpdate<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.FindOneAndUpdate(session, filter, update, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndUpdateAsync<TProjection>(FilterDefinition<T> filter, UpdateDefinition<T> update, FindOneAndUpdateOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.FindOneAndUpdateAsync(filter, update, options, cancellationToken);
        }

        public Task<TProjection> FindOneAndUpdateAsync<TProjection>(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update,
            FindOneAndUpdateOptions<T, TProjection> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.FindOneAndUpdateAsync(session, filter, update, options, cancellationToken);
        }

        public void InsertMany(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(documents);

            MongoCollectionBase.InsertMany(documents, options, cancellationToken);
        }

        public void InsertMany(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(documents);

            MongoCollectionBase.InsertMany(session, documents, options, cancellationToken);
        }

        public Task InsertManyAsync(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(documents);

            return MongoCollectionBase.InsertManyAsync(documents, options, cancellationToken);
        }

        public Task InsertManyAsync(IClientSessionHandle session, IEnumerable<T> documents, InsertManyOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(documents);

            return MongoCollectionBase.InsertManyAsync(session, documents, options, cancellationToken);
        }

        [Obsolete]
        public IAsyncCursor<TResult> MapReduce<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.MapReduce(map, reduce, options, cancellationToken);
        }

        [Obsolete]
        public IAsyncCursor<TResult> MapReduce<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.MapReduce(session, map, reduce, options, cancellationToken);
        }

        public void InsertOne(T document, InsertOneOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(document);

            MongoCollectionBase.InsertOne(document, options, cancellationToken);
        }

        public void InsertOne(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(document);

            MongoCollectionBase.InsertOne(session, document, options, cancellationToken);
        }

        [Obsolete]
        public Task InsertOneAsync(T document, CancellationToken cancellationToken)
        {
            PrepareInsert(document);

            return MongoCollectionBase.InsertOneAsync(document, cancellationToken);
        }

        public Task InsertOneAsync(T document, InsertOneOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(document);

            return MongoCollectionBase.InsertOneAsync(document, options, cancellationToken);
        }

        public Task InsertOneAsync(IClientSessionHandle session, T document, InsertOneOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareInsert(document);

            return MongoCollectionBase.InsertOneAsync(session, document, options, cancellationToken);
        }

        [Obsolete]
        public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.MapReduceAsync(map, reduce, options, cancellationToken);
        }

        [Obsolete]
        public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<T, TResult> options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.MapReduceAsync(session, map, reduce, options, cancellationToken);
        }

        IFilteredMongoCollection<TDerivedDocument> IMongoCollection<T>.OfType<TDerivedDocument>()
        {
            return MongoCollectionBase.OfType<TDerivedDocument>();
        }

        public ReplaceOneResult ReplaceOne(FilterDefinition<T> filter, T replacement, ReplaceOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOne(filter, replacement, options, cancellationToken);
        }

        [Obsolete]
        public ReplaceOneResult ReplaceOne(FilterDefinition<T> filter, T replacement, UpdateOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOne(filter, replacement, options, cancellationToken);
        }

        public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<T> filter, T replacement, ReplaceOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOne(session, filter, replacement, options, cancellationToken);
        }

        [Obsolete]
        public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<T> filter, T replacement, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOne(session, filter, replacement, options, cancellationToken);
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<T> filter, T replacement, ReplaceOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOneAsync(filter, replacement, options, cancellationToken);
        }

        [Obsolete]
        public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<T> filter, T replacement, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOneAsync(filter, replacement, options, cancellationToken);
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, T replacement, ReplaceOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOneAsync(session, filter, replacement, options, cancellationToken);
        }

        [Obsolete]
        public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, T replacement, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareReplacement(replacement);

            return MongoCollectionBase.ReplaceOneAsync(session, filter, replacement, options, cancellationToken);
        }

        public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateMany(filter, update, options, cancellationToken);
        }

        public UpdateResult UpdateMany(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateMany(session, filter, update, options, cancellationToken);
        }

        public Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateManyAsync(filter, update, options, cancellationToken);
        }

        public Task<UpdateResult> UpdateManyAsync(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateManyAsync(session, filter, update, options, cancellationToken);
        }

        public UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateOne(filter, update, options, cancellationToken);
        }

        public UpdateResult UpdateOne(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateOne(session, filter, update, options, cancellationToken);
        }

        public Task<UpdateResult> UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateOneAsync(filter, update, options, cancellationToken);
        }

        public Task<UpdateResult> UpdateOneAsync(IClientSessionHandle session, FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PrepareUpdate(update);

            return MongoCollectionBase.UpdateOneAsync(session, filter, update, options, cancellationToken);
        }

        public IChangeStreamCursor<TResult> Watch<TResult>(PipelineDefinition<ChangeStreamDocument<T>, TResult> pipeline, ChangeStreamOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Watch(pipeline, options, cancellationToken);
        }

        public IChangeStreamCursor<TResult> Watch<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<T>, TResult> pipeline, ChangeStreamOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.Watch(session, pipeline, options, cancellationToken);
        }

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(PipelineDefinition<ChangeStreamDocument<T>, TResult> pipeline, ChangeStreamOptions options = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.WatchAsync(pipeline, options, cancellationToken);
        }

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<T>, TResult> pipeline,
            ChangeStreamOptions options = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return MongoCollectionBase.WatchAsync(session, pipeline, options, cancellationToken);
        }

        public IMongoCollection<T> WithReadConcern(ReadConcern readConcern)
        {
            return MongoCollectionBase.WithReadConcern(readConcern);
        }

        public IMongoCollection<T> WithReadPreference(ReadPreference readPreference)
        {
            return MongoCollectionBase.WithReadPreference(readPreference);
        }

        public IMongoCollection<T> WithWriteConcern(WriteConcern writeConcern)
        {
            return MongoCollectionBase.WithWriteConcern(writeConcern);
        }

        private void PrepareInsert(T document)
        {
            if (document.CreatedAt.IsEmpty())
            {
                document.CreatedAt = DateTime.UtcNow;
            }
        }

        private void PrepareInsert(IEnumerable<T> documents)
        {
            foreach (var document in documents)
            {
                PrepareInsert(document);
            }
        }

        private void PrepareReplacement(T replacement)
        {
            if (!replacement.Id.IsEmpty())
            {
                replacement.UpdatedAt = DateTime.UtcNow;
            }
        }

        private void PrepareUpdate(UpdateDefinition<T> document)
        {
            document.Set(entity => entity.UpdatedAt, DateTime.UtcNow);
        }

        public void AggregateToCollection<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
        {
            MongoCollectionBase.AggregateToCollection(pipeline, options, cancellationToken);
        }

        public void AggregateToCollection<TResult>(IClientSessionHandle session, PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
        {
            MongoCollectionBase.AggregateToCollection(session, pipeline, options, cancellationToken);
        }

        public Task AggregateToCollectionAsync<TResult>(PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
        {
            return MongoCollectionBase.AggregateToCollectionAsync(pipeline, options, cancellationToken);
        }

        public Task AggregateToCollectionAsync<TResult>(IClientSessionHandle session, PipelineDefinition<T, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
        {
            return MongoCollectionBase.AggregateToCollectionAsync(session, pipeline, options, cancellationToken);
        }
    }
}