using AutoMapper;
using MongoDB.Bson;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AddUser, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.GenerateNewId()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
