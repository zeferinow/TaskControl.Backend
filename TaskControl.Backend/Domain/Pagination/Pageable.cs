using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TaskControl.Backend.Domain.Pagination
{
    public abstract class Pageable
    {
        [IgnoreDataMember]
        [NotMapped]
        [BsonIgnore]
        public int RowNum { get; set; }

        [IgnoreDataMember]
        [NotMapped]
        [BsonIgnore]
        public int TotalRowCount { get; set; }
    }
}
