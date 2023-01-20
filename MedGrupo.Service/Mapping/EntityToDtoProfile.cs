using AutoMapper;
using MedGrupo.Domain.Dtos.Contact;
using MedGrupo.Domain.Dtos.User;
using MedGrupo.Domain.Entities;

namespace MedGrupo.Service.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

            CreateMap<ContactDto, ContactEntity>().ReverseMap();
            //CreateMap<ContactCreateResult, ContactEntity>().ReverseMap();
            //CreateMap<ContactUpdateResult, ContactEntity>().ReverseMap();
        }
    }
}
