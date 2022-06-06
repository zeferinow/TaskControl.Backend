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
        public Lazy<ITaskListRepository> TaskListRepository { get; set; }

        public IQueryable<TaskEntity> GetAll()
        {
            return TaskMongoDbRepository.Value.GetAll();
        }

        public TaskEntity GetById(ObjectId ticketId)
        {
            return TaskMongoDbRepository.Value.GetById(ticketId);
        }

        public TaskEntity GetStatus(ObjectId ticketId)
        {
            throw new NotImplementedException();
        }

        public TaskEntity Update(TaskEntity task)
        {
            var ticketEntity = TaskMongoDbRepository.Value.Update(task);

            TaskListRepository.Value.Update(task);

            return ticketEntity;
        }

        public void Add(TaskEntity task)
        {
            TaskMongoDbRepository.Value.Add(task);
            TaskListRepository.Value.Add(task);
        }

        public void AddDescription(TaskDescriptionEntity description)
        {
            TaskDescriptionMongoDbRepository.Value.Add(description);
        }

        public string GetDescriptionPlainTextById(ObjectId descriptionId)
        {
            return TaskDescriptionMongoDbRepository.Value.GetAll().Where(description => description.Id == descriptionId).Select(description => description.DescriptionPlainText).FirstOrDefault();
        }
    }
}
