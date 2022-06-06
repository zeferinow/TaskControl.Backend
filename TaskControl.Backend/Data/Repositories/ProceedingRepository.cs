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

        public IEnumerable<ProceedingEntity> Get(IEnumerable<ObjectId> proceedingsIds)
        {
            return ProceedingRepositoryInternal.Value.GetAll().Where(proceeding => proceedingsIds.Contains(proceeding.Id));
        }

        public IQueryable<ProceedingEntity> GetAll()
        {
            return ProceedingRepositoryInternal.Value.GetAll();
        }

        public string GetDescription(ObjectId proceedingId)
        {
            var description = ProceedingDescriptionRepository.Value.GetAll().FirstOrDefault(x => x.ProceedingId == proceedingId);
            if(description != null)
            {
                return description.DescriptionPlainText;
            }

            return null;
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
