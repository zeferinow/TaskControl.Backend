using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Extensions;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Mappings
{
    public class TaskListMapping : Profile
    {
        public TaskListMapping()
        {
            CreateMap<TaskEntity, TaskListEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SequenceNumber, opt => opt.MapFrom(src => src.SequenceNumber))
                .ForMember(dest => dest.GeneratorId, opt => opt.MapFrom(src => src.GeneratorId.ToString()))
                .ForMember(dest => dest.ResponsibleId, opt => opt.MapFrom(src => src.ResponsibleId))
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(src => src.OpeningDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DescriptionId, opt => opt.MapFrom(src => src.DescriptionId))
                .ForMember(dest => dest.ProceedingsIds, opt => opt.MapFrom(src => src.ProceedingsIds));

            CreateMap<TaskListEntity, TaskListData>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId.ToString()))
                .ForMember(dest => dest.SequenceNumber, opt => opt.MapFrom(src => src.SequenceNumber))
                .ForMember(dest => dest.ResponsibleId, opt => opt.MapFrom(src => src.ResponsibleId))
                .ForMember(dest => dest.ResponsibleName, opt => opt.MapFrom(src => src.ResponsibleName))
                .ForMember(dest => dest.GeneratorId, opt => opt.MapFrom(src => src.GeneratorId.ToString()))
                .ForMember(dest => dest.GeneratorName, opt => opt.MapFrom(src => src.GeneratorName))
                .ForMember(dest => dest.NumberOfProceedings, opt => opt.MapFrom(src => src.NumberOfProceedings))
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(src => src.OpeningDate))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.EStatusToString()));

            CreateMap<TaskListEntity, TaskView>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId.ToString()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.SequenceNumber, opt => opt.MapFrom(src => src.SequenceNumber))
                .ForMember(dest => dest.ResponsibleId, opt => opt.MapFrom(src => src.ResponsibleId.ToString()))
                .ForMember(dest => dest.ResponsibleName, opt => opt.MapFrom(src => src.ResponsibleName))
                .ForMember(dest => dest.GeneratorId, opt => opt.MapFrom(src => src.GeneratorId.ToString()))
                .ForMember(dest => dest.ProceedingsIds, opt => opt.MapFrom(src => src.ProceedingsIds))
                .ForMember(dest => dest.NumberOfProceedings, opt => opt.MapFrom(src => src.NumberOfProceedings))
                .ForMember(dest => dest.OpeningDate, opt => opt.MapFrom(src => src.OpeningDate.ToString()));
        }
    }
}
