using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Data.Repositories
{
    public interface ISequenceRepository
    {
        int GetSequenceValue(ESequenceType sequenceType);
        int GetSequenceValue(ESequenceType sequenceType, ObjectId ticketId);
    }
}
