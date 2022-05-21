using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Domain
{
    public interface IBaseUserContext
    {
        ObjectId UserId { get; }
        long TokenExpirationSeconds { get; }
        bool EmailUser { get; }
    }
}
