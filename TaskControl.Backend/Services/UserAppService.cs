using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Repositories;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Services
{
    [LazyInjection]
    public class UserAppService
    {
        public Lazy<IUserRepository> UserRepository { get; set; }

        public UserEntity GetById(ObjectId id)
        {
            return UserRepository.Value.GetById(id);
        }

        public IQueryable<UserEntity> GetByLogin(string login)
        {
            return UserRepository.Value.GetAll().Where(u => u.Login == login);
        }

    }
}
