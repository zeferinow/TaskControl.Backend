using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Repositories;
using TaskControl.Backend.Domain;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Services
{
    [LazyInjection]
    public class UserAppService
    {
        public Lazy<IUserRepository> UserRepository { get; set; }
        public Lazy<IUserContext> UserContext { get; set; }
        public Lazy<IMapper> Mapper { get; set; }

        public UserEntity GetById(ObjectId id)
        {
            return UserRepository.Value.GetById(id);
        }

        public IQueryable<UserEntity> GetByLogin(string login)
        {
            return UserRepository.Value.GetAll().Where(u => u.Login == login);
        }

        public void ValidatePermission()
        {
            if (!IsCurrentUserAdmin())
            {
                throw new Exception("Not allowed");
            }
        }

        public bool IsCurrentUserAdmin()
        {
            if(UserContext.Value.UserId == "627d26e257d80d080a1afbe7".ToObjectId())
            {
                return true;
            }
            return false;
        }

        public void Add(AddUser addUser)
        {
            var userEntity = Mapper.Value.Map<AddUser, UserEntity>(addUser);

            try
            {
                ValidatePermission();
                UserRepository.Value.Add(userEntity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<UserListData> GetData()
        {
            return GetUserList<UserListData>();
        }

        private IQueryable<UserListData> GetUserList<T>() where T : UserListData
        {
            ValidatePermission();

            var userList = UserRepository.Value.GetAll();

            var userListValues = new List<UserListData>();

            foreach (var item in userList)
            {
                var user = Mapper.Value.Map<UserEntity, UserListData>(item);

                userListValues.Add(user);
            }

            return userListValues.AsQueryable();
        }

        public void Update(UpdateUser updateUser)
        {
            var user = UserRepository.Value.GetById(updateUser.UserId.ToObjectId());
            var dateNow = DateTime.Now;
            try
            {
                ValidatePermission();
                user.Name = updateUser.Name;
                user.Login = updateUser.Login;
                user.Password = updateUser.Password;
                user.Phone = updateUser.Phone;
                user.Cpf = updateUser.Cpf;
                user.Email = updateUser.Email;
                UserRepository.Value.Update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string userId)
        {
            ValidatePermission();
            UserRepository.Value.Delete(userId.ToObjectId());
        }
    }
}
