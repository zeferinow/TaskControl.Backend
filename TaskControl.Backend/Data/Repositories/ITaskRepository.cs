using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    public interface ITaskRepository
    {
        IQueryable<TaskEntity> GetAll();
        TaskEntity GetById(ObjectId ticketId);
        TaskEntity GetStatus(ObjectId ticketId);
        TaskEntity Update(TaskEntity ticketEntity);
        void Add(TaskEntity ticketEntity);
        void AddDescription(TaskDescriptionEntity ticket);
    }
}
