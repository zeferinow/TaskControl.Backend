using MongoDB.Bson;

namespace TaskControl.Backend.Entities.MongoDb
{
    public class UserEntity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }                         
    }
}
