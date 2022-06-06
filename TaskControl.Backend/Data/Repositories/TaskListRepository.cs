using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;

namespace TaskControl.Backend.Data.Repositories
{
    [LazyInjection]
    public class TaskListRepository : ITaskListRepository
    {
        public Lazy<IMongoDbRepository<TaskListEntity>> TaskListRepositoryInternal { get; set; }
        public Lazy<IMapper> Mapper { get; set; }
        public Lazy<IUserRepository> UserRepository { get; set; }
        public Lazy<IProceedingRepository> ProceedingRepository { get; set; }

        public void Add(TaskEntity taskEntity)
        {
            var taskListEntity = Mapper.Value.Map<TaskListEntity>(taskEntity);

            taskListEntity.Id = ObjectId.GenerateNewId();
            taskListEntity.TaskId = taskEntity.Id;

            LoadTaskListPropertiesValues(taskListEntity, taskEntity);

            TaskListRepositoryInternal.Value.Add(taskListEntity);
        }
        
        public IQueryable<T> GetAllByCollectionType<T>() where T : TaskListEntity
        {
            return TaskListRepositoryInternal.Value.GetAll() as IQueryable<T>;
        }

        public void LoadTaskListPropertiesValues(TaskListEntity taskListEntity, TaskEntity taskEntity)
        {
            var generator = UserRepository.Value.GetById(taskEntity.GeneratorId);

            if (generator != null)
            {
                taskListEntity.GeneratorName = generator.Name;
            }

            if (taskEntity.ResponsibleId.HasValue)
            {
                var responsible = UserRepository.Value.GetById(taskEntity.ResponsibleId.Value);

                if (responsible != null)
                {
                    taskListEntity.ResponsibleName = responsible.Name;
                }
            }

            if (taskEntity.ProceedingsIds != null)
            {
                taskListEntity.NumberOfProceedings = taskEntity.ProceedingsIds.Count();

                if (taskEntity.ProceedingsIds.Any())
                {
                    var proceedings = ProceedingRepository.Value.Get(taskEntity.ProceedingsIds);

                    var proceedingGeneratorsIds = new List<ObjectId>();
                    var proceedingGeneratorGroupsIds = new List<ObjectId>();
                    var proceedingsDates = new List<DateTime>();

                    foreach (var proceeding in proceedings)
                    {
                        proceedingGeneratorsIds.Add(proceeding.GeneratorId);
                        proceedingsDates.Add(proceeding.Date);
                    }

                    taskListEntity.ProceedingGeneratorsIds = proceedingGeneratorsIds.Any() ? proceedingGeneratorsIds : null;
                    taskListEntity.ProceedingsDates = proceedingsDates.Any() ? proceedingsDates : null;

                    var lastProceeding = proceedings.OrderByDescending(proceeding => proceeding.Id).FirstOrDefault();

                    if (lastProceeding != null)
                    {
                        taskListEntity.LastProceedingDate = lastProceeding.Date;
                    }
                }
            }

        }

        public void Update(TaskEntity taskEntity)
        {
            var taskListEntity = Get(taskEntity.Id);

            taskListEntity = Mapper.Value.Map(taskEntity, taskListEntity);

            LoadTaskListPropertiesValues(taskListEntity, taskEntity);

            Update(taskListEntity);
        }

        public void Update(TaskListEntity taskListEntity)
        {
            TaskListRepositoryInternal.Value.Update(taskListEntity);
        }

        public TaskListEntity Get(ObjectId taskId)
        {
            return TaskListRepositoryInternal.Value.GetAll()
                .FirstOrDefault(taskListEntity => taskListEntity.TaskId == taskId);
        }

        public TaskListEntity GetById(string taskId)
        {
            return TaskListRepositoryInternal.Value.GetAll()
                .FirstOrDefault(taskListEntity => taskListEntity.TaskId == taskId.ToObjectId());
        }
    }
}
