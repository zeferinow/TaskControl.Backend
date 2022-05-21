using MongoDB.Bson;
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
    public class ProceedingRepository : IProceedingRepository
    {
        public Lazy<IMongoDbRepository<ProceedingEntity>> ProceedingRepositoryInternal { get; set; }
        public Lazy<IMongoDbRepository<ProceedingDescriptionEntity>> ProceedingDescriptionRepository { get; set; }

        public void Add(ProceedingEntity proceedingEntity)
        {
            ProceedingRepositoryInternal.Value.Add(proceedingEntity);
        }

        public void AddDescription(ProceedingDescriptionEntity proceedingDescriptionEntity)
        {
            ProceedingDescriptionRepository.Value.Add(proceedingDescriptionEntity);
        }

        public ProceedingEntity Get(ObjectId proceedingId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProceedingEntity> GetAll()
        {
            return ProceedingRepositoryInternal.Value.GetAll();
        }

        public ProceedingEntity GetUserTaskProceeding(TaskEntity ticketId, UserEntity userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProceedingEntity> GetUserTaskProceedings(ObjectId taskId)
        {
            var proceedingQuery = ProceedingRepositoryInternal.Value.GetAll().Where(proceeding => proceeding.TaskId == taskId);

            return proceedingQuery;
        }
    }
}
