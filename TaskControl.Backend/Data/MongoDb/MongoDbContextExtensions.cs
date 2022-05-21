using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaskControl.Backend.Extensions;

namespace TaskControl.Backend.Data.MongoDb
{
    public static class MongoDbContextExtensions
    {
        public static IMongoCollection<T> GetCollection<T>(this MongoDbContext mongoDbContext)
        {
            var collectionName = typeof(T).GetCollectionName();

            return mongoDbContext.Database.GetCollection<T>(collectionName);
        }

        public static string GetCollectionName(this Type type)
        {
            var bsonDiscriminatorAttribute = type.GetTypeInfo().GetCustomAttributes<BsonDiscriminatorAttribute>().FirstOrDefault();
            var collectionName = bsonDiscriminatorAttribute != null ? bsonDiscriminatorAttribute.Discriminator : type.Name.TrimEnd("Entity");
            return collectionName;
        }
    }
}
