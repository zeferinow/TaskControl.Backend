using MongoDB.Bson;
using System.Linq;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    public interface IUserRepository
    {
        IQueryable<UserEntity> GetAll();
        UserEntity GetById(ObjectId userId);
        string GetName(ObjectId userId);
        UserEntity Update(UserEntity user);
        void Delete(ObjectId objectId);
        void Add(UserEntity userEntity);
    }
}
