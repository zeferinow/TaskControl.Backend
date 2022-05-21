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
        public Lazy<IUserRepository> UserRepository { get; set; }

        public TaskEntity Add(AddTask addTask)
        {
            ValidateHtmlDescriptionSize(addTask.Description?.Text);

            var taskEntity = Mapper.Value.Map<AddTask, TaskEntity>(addTask);

            //taskEntity.GeneratorId = UserContext.Value.UserId;
            taskEntity.GeneratorId = "627d26e257d80d080a1afbe7".ToObjectId();

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

        public TaskDescriptionEntity AddDescription(string description, ObjectId taskId)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return null;
            }

            var taskDescription = new TaskDescriptionEntity
            {
                DescriptionPlainText = description.ToPlainText().ToLower(),
                TaskId = taskId
            };

            TaskRepository.Value.AddDescription(taskDescription);

            return taskDescription;
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
    }
}
