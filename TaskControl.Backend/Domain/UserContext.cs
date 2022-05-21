using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Domain
{
    public class UserContext : IUserContext
    {
        public ObjectId UserId { get; set; }
        public long TokenExpirationSeconds { get; set; }
        public bool EmailUser { get; set; }

        public UserContext()
        {
        }

        public UserContext(IBaseUserContext userContext)
        {
            UserId = userContext.UserId;
            TokenExpirationSeconds = userContext.TokenExpirationSeconds;
            EmailUser = userContext.EmailUser;
        }
    }
}
