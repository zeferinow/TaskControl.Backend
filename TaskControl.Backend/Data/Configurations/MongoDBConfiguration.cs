using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Data.Configurations
{
    public class MongoDBConfiguration : IMongoDBConfiguration
    {
        public string AppConnectionString { get; set; }
        public string AppDataBase { get; set; }
    }
}
