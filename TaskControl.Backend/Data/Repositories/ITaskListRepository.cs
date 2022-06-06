using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    public interface ITaskListRepository
    {
        IQueryable<T> GetAllByCollectionType<T>() where T : TaskListEntity;
        void Add(TaskEntity taskEntity);
        void Update(TaskEntity taskEntity);
        TaskListEntity GetById(string taskId);
    }
}
