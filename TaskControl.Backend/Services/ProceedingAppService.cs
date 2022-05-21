using AutoMapper;
using System;
using System.Text;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Repositories;
using TaskControl.Backend.Domain;
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

        public ProceedingEntity AddProceeding(TaskEntity taskEntity, AddProceeding addProceeding)
        {
            var originalTask = TaskRepository.Value.GetById(taskEntity.Id);
            
            try
            {
                var proceedingEntity = Add(addProceeding);

                return proceedingEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProceedingEntity Add(AddProceeding addProceeding)
        {
            var dateNow = DateTime.Now;
            ValidateHtmlDescriptionSize(addProceeding.Description.Text);

            var proceedingEntity = Mapper.Value.Map<AddProceeding, ProceedingEntity>(addProceeding);

            proceedingEntity.Date = dateNow;
            //proceedingEntity.GeneratorId = UserContext.Value.UserId;
            proceedingEntity.GeneratorId = "627d26e257d80d080a1afbe7".ToObjectId();

            AddDescription(addProceeding.Description.Text, proceedingEntity);

            ProceedingRepository.Value.Add(proceedingEntity);

            return proceedingEntity;
        }

        public string AddDescription(string description, ProceedingEntity proceedingEntity)
        {
            var proceedingDescriptionEntity = new ProceedingDescriptionEntity
            {
                TaskId = proceedingEntity.TaskId,
                ProceedingId = proceedingEntity.Id,
                DescriptionPlainText = description.ToPlainText().ToLower()
            };

            ProceedingRepository.Value.AddDescription(proceedingDescriptionEntity);

            proceedingEntity.DescriptionId = proceedingDescriptionEntity.Id;

            return description;
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
