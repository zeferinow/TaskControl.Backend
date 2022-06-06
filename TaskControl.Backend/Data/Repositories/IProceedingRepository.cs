using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;

namespace TaskControl.Backend.Data.Repositories
{
    public interface IProceedingRepository
    {
        ProceedingEntity GetUserTaskProceeding(TaskEntity ticketId, UserEntity userId);
        IQueryable<ProceedingEntity> GetUserTaskProceedings(ObjectId ticketId);
        void Add(ProceedingEntity proceedingEntity);
        ProceedingEntity Get(ObjectId proceedingId);
        IEnumerable<ProceedingEntity> Get(IEnumerable<ObjectId> proceedingsIds);
        IQueryable<ProceedingEntity> GetAll();
        void AddDescription(ProceedingDescriptionEntity proceedingDescriptionEntity);
        string GetDescription(ObjectId proceedingId);
    }
}
