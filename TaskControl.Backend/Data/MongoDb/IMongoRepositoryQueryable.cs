using MongoDB.Bson;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskControl.Backend.Data.MongoDb
{
    public interface IMongoRepositoryQueryable<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(ObjectId id);
        Task<T> GetByIdAsync(ObjectId id, CancellationToken cancellationToken = default);
    }
}
