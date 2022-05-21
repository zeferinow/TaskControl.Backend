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
    public class TaskMapping : Profile
    {
        public TaskMapping()
        {
            CreateMap<AddTask, TaskEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.GenerateNewId()))
                .ForMember(dest => dest.SequenceNumber, opt => opt.MapFrom(src => src.SequenceNumber))
                .ForMember(dest => dest.ResponsibleId, opt => opt.MapFrom(src => src.ResponsibleId.ToNullableObjectId()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<TaskEntity, TaskResume>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SequenceNumber, opt => opt.MapFrom(src => src.SequenceNumber))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(src => src.OpeningDate));
        }
    }
}
