using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Configurations;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Domain;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class UserRepository : IUserRepository
    {
        public Lazy<IMongoDbRepository<UserEntity>> UserMongoDbRepository { get; set; }

        public IQueryable<UserEntity> GetAll()
        {
            return UserMongoDbRepository.Value.GetAll();
        }

        public UserEntity GetById(ObjectId userId)
        {
            return UserMongoDbRepository.Value.GetById(userId);
        }

        public string GetName(ObjectId userId)
        {
            return UserMongoDbRepository.Value.GetAll().Where(entity => entity.Id == userId).Select(entity => entity.Name).FirstOrDefault();
        }

        public UserEntity Update(UserEntity user)
        {
            return UserMongoDbRepository.Value.Update(user);
        }

        public void Delete(ObjectId userId)
        {
            UserMongoDbRepository.Value.Delete(userId);
        }

        public void Add(UserEntity userEntity)
        {
            UserMongoDbRepository.Value.Add(userEntity);
        }
    }
}
