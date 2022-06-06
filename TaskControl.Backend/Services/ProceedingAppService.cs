using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ProceedingAppService
    {
        public Lazy<IMapper> Mapper { get; set; }
        public Lazy<IUserContext> UserContext { get; set; }
        public Lazy<ITaskRepository> TaskRepository { get; set; }
        public Lazy<IProceedingRepository> ProceedingRepository { get; set; }
        public Lazy<ISequenceRepository> SequenceRepository { get; set; }
        public Lazy<IUserRepository> UserRepository { get; set; }

        public ProceedingEntity AddProceeding(TaskEntity taskEntity, AddProceeding addProceeding)
        {
            var originalTask = TaskRepository.Value.GetById(taskEntity.Id);

            try
            {
                var proceedingEntity = Add(addProceeding, originalTask, taskEntity);

                return proceedingEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProceedingEntity Add(AddProceeding addProceeding, TaskEntity originalTask, TaskEntity taskEntity)
        {
            var dateNow = DateTime.Now;
            ValidateRegisterProceeding(originalTask);
            ValidateHtmlDescriptionSize(addProceeding.Description.Text);

            var proceedingEntity = Mapper.Value.Map<AddProceeding, ProceedingEntity>(addProceeding);

            proceedingEntity.Date = dateNow;
            proceedingEntity.GeneratorId = UserContext.Value.UserId;

            proceedingEntity.SequenceNumber = SequenceRepository.Value.GetSequenceValue(ESequenceType.Proceeding, addProceeding.TaskId.ToObjectId());

            AddDescription(addProceeding.Description.Text, proceedingEntity);

            ProceedingRepository.Value.Add(proceedingEntity);

            var proceedingsIds = taskEntity.ProceedingsIds?.ToList() ?? new List<ObjectId>();

            proceedingsIds.Add(proceedingEntity.Id);
            taskEntity.ProceedingsIds = proceedingsIds;
            taskEntity.Status = addProceeding.Status;
            if(taskEntity.ResponsibleId == null)
            {
                taskEntity.ResponsibleId = UserContext.Value.UserId;
            }

            TaskRepository.Value.Update(taskEntity);

            return proceedingEntity;
        }

        public string AddDescription(string description, ProceedingEntity proceedingEntity)
        {
            var proceedingDescriptionEntity = new ProceedingDescriptionEntity
            {
                TaskId = proceedingEntity.TaskId,
                ProceedingId = proceedingEntity.Id,
                DescriptionPlainText = description
            };

            ProceedingRepository.Value.AddDescription(proceedingDescriptionEntity);

            proceedingEntity.DescriptionId = proceedingDescriptionEntity.Id;

            return description;
        }

        public IQueryable<ProceedingView> GetProceedingData(string taskId)
        {
            return GetProceedingList(taskId);
        }

        public IQueryable<ProceedingView> GetProceedingList(string taskId)
        {
            var proceedingsObjectIds = ProceedingRepository.Value.GetUserTaskProceedings(taskId.ToObjectId());

            var proceedings = new List<ProceedingView>();

            foreach (var item in proceedingsObjectIds)
            {
                var proceeding = Mapper.Value.Map<ProceedingEntity, ProceedingView>(item);
                proceeding.GeneratorName = UserRepository.Value.GetName(item.GeneratorId);
                proceeding.DescriptionText = ProceedingRepository.Value.GetDescription(item.Id);
                proceedings.Add(proceeding);
            }

            return proceedings.AsQueryable();
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

        private void ValidateRegisterProceeding(TaskEntity originalTask)
        {
            var user = UserContext.Value.UserId;

            if(originalTask.ResponsibleId != null)
            {
                if (user != originalTask.GeneratorId && user != originalTask.ResponsibleId)
                {
                    throw new Exception("Not allowed to register proceedings in this task");
                }
            }
        }
    }
}
