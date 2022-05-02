using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Configurations;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _user;

        public UserRepository(IMongoDBConfiguration mongoDBConfiguration)
        {
            var client = new MongoClient(mongoDBConfiguration.AppConnectionString);
            var collection = client.GetDatabase(mongoDBConfiguration.AppDataBase);

            _user = collection.GetCollection<UserEntity>("users");
        }

        public IQueryable<UserEntity> GetAll()
        {
            return _user.AsQueryable();
        }

        public UserEntity GetById(ObjectId userId)
        {
            return _user.Find(user => user.Id == userId).FirstOrDefault();
        }

        public string GetName(ObjectId userId)
        {
            return _user.Find(user => user.Id == userId).FirstOrDefault().ToString(); //SEARCH FOR HOW TO SELECT ONLY NAME
        }
    }
}
