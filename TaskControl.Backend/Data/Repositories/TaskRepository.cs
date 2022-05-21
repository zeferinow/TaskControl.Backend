using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class TaskRepository : ITaskRepository
    {
        public Lazy<IMongoDbRepository<TaskEntity>> TaskMongoDbRepository { get; set; }
        public Lazy<IMongoDbRepository<TaskDescriptionEntity>> TaskDescriptionMongoDbRepository { get; set; }

        public IQueryable<TaskEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskEntity GetById(ObjectId ticketId)
        {
            return TaskMongoDbRepository.Value.GetById(ticketId);
        }

        public TaskEntity GetStatus(ObjectId ticketId)
        {
            throw new NotImplementedException();
        }

        public TaskEntity Update(TaskEntity ticketEntity)
        {
            throw new NotImplementedException();
        }

        public void Add(TaskEntity task)
        {
            TaskMongoDbRepository.Value.Add(task);
        }

        public void AddDescription(TaskDescriptionEntity ticket)
        {
            TaskDescriptionMongoDbRepository.Value.Add(ticket);
        }
    }
}
