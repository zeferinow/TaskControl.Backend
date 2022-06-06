using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Repositories;
using TaskControl.Backend.Domain;
using TaskControl.Backend.Domain.Enums;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Services
{
    [LazyInjection]
    public class TaskAppService
    {
        public Lazy<IMapper> Mapper { get; set; }
        public Lazy<IUserContext> UserContext { get; set; }
        public Lazy<ITaskRepository> TaskRepository { get; set; }
        public Lazy<ITaskListRepository> TaskListRepository { get; set; }
        public Lazy<IUserRepository> UserRepository { get; set; }
        public Lazy<ISequenceRepository> SequenceRepository { get; set; }
        public Lazy<IProceedingRepository> ProceedingRepository { get; set; }

        public TaskEntity Add(AddTask addTask)
        {
            ValidateHtmlDescriptionSize(addTask.Description?.Text);

            var taskEntity = Mapper.Value.Map<AddTask, TaskEntity>(addTask);

            taskEntity.GeneratorId = UserContext.Value.UserId;

            try
            {
                var taskDescriptionEntity = AddDescription(addTask.Description?.Text, taskEntity.Id);

                taskEntity.DescriptionId = taskDescriptionEntity?.Id;

                Add(taskEntity);

                return taskEntity;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Add(TaskEntity taskEntity)
        {
            var dateNow = DateTime.Now;

            taskEntity.OpeningDate = dateNow;

            TaskRepository.Value.Add(taskEntity);
        }

        public IQueryable<TaskListData> GetData()
        {
            return GetTaskList<TaskListEntity>();
        }

        public IQueryable<TaskListData> GetTaskList<T>() where T : TaskListEntity
        {
            var taskList = TaskListRepository.Value.GetAllByCollectionType<T>();

            var taskListValues = new List<TaskListData>();
            //IQueryable<TaskListData> taskListValues = Enumerable.Empty<TaskListData>().AsQueryable();

            foreach (var item in taskList)
            {
                var task = Mapper.Value.Map<TaskListEntity, TaskListData>(item);

                taskListValues.Add(task);
            }

            return taskListValues.AsQueryable();
        }

        public TaskView GetTask(string taskId)
        {
            var task = TaskListRepository.Value.GetById(taskId);

            var taskView = Mapper.Value.Map<TaskListEntity, TaskView>(task);

            taskView.DescriptionPlainText = GetDescriptionPlainTextById(taskView.DescriptionId);

            return taskView;
        }

        public TaskDescriptionEntity AddDescription(string description, ObjectId taskId)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return null;
            }

            var taskDescription = new TaskDescriptionEntity
            {
                DescriptionPlainText = description,
                TaskId = taskId
            };

            TaskRepository.Value.AddDescription(taskDescription);

            return taskDescription;
        }

        public void Update(ObjectId taskId, UpdateTask updateTask)
        {
            var task = GetCurrentUserTask(taskId);
            var dateNow = DateTime.UtcNow;

            VerifyExistsTicket(task);

            var originalticket = GetCurrentUserTask(taskId);

            var userId = UserContext.Value.UserId;

            try
            {
                if (task.ResponsibleId != null)
                {
                    if (task.ResponsibleId != userId && task.GeneratorId != userId)
                    {
                        throw new Exception("You're not allowed to change this task.");
                    } 
                }

                //var responsibleId = updateTask.ResponsibleId.ToNullableObjectId();

                task.Status = updateTask.Status;

                task.ResponsibleId = userId;

                TaskRepository.Value.Update(task);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public string GetDescriptionPlainTextById(string descriptionId)
        {
            return TaskRepository.Value.GetDescriptionPlainTextById(descriptionId.ToObjectId());
        }

        public int GetNewSequenceNumber()
        {
            return SequenceRepository.Value.GetSequenceValue(ESequenceType.Task);
        }

        public TaskEntity GetCurrentUserTask(ObjectId taskId)
        {
            var taskEntity = TaskRepository.Value.GetById(taskId);

            return taskEntity;
        }

        public TaskResume ConvertTaskToTaskResume(TaskEntity taskEntity)
        {
            var taskResume = Mapper.Value.Map<TaskEntity, TaskResume>(taskEntity);

            taskResume.GeneratorName = UserRepository.Value.GetById(taskEntity.GeneratorId).Name;
            taskResume.StatusName = taskEntity.Status.ToString();
            taskResume.ResponsibleName = taskEntity.ResponsibleId.HasValue ? UserRepository.Value.GetById(taskEntity.ResponsibleId.Value).Name : null;

            return taskResume;
        }

        public void ValidateHtmlDescriptionSize(string description)
        {
            var inputHtmlInBytes = 15777216;

            if (string.IsNullOrWhiteSpace(description))
            {
                return;
            }

            var size = Encoding.UTF8.GetByteCount(description);

            if (size > inputHtmlInBytes)
            {
                throw new Exception("Description size limit reached");
            }
        }

        private void VerifyExistsTicket(TaskEntity task)
        {
            if (task == null)
            {
                throw new Exception();
            }
        }
    }
}
