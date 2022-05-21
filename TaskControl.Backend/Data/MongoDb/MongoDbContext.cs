using MongoDB.Driver;
using TaskControl.Backend.Data.Configurations;

namespace TaskControl.Backend.Data.MongoDb
{
    public class MongoDbContext
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }

        public MongoDbContext(IMongoDBConfiguration mongoDbConfiguration)
        {
            Client = new MongoClient(mongoDbConfiguration.AppConnectionString);

            Database = Client.GetDatabase(mongoDbConfiguration.AppDataBase);
        }
    }
}
