using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Mappings
{
    public class ProceedingMapping : Profile
    {
        public ProceedingMapping()
        {
            CreateMap<AddProceeding, ProceedingEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.GenerateNewId()))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId.ToObjectId()));
        }
    }
}
