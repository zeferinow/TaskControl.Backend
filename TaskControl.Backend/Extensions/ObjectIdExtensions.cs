using MongoDB.Bson;

namespace TaskControl.Backend.Extensions
{
    public static class ObjectIdExtensions
    {
        public static bool IsEmpty(this ObjectId id)
        {
            return id == ObjectId.Empty;
        }

        public static ObjectId? ToNullableObjectId(this ObjectId id)
        {
            return id.IsEmpty() ? (ObjectId?)null : id;
        }
    }
}
