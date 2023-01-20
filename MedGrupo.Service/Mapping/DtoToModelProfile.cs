using AutoMapper;
using MedGrupo.Domain.Dtos.User;
using MedGrupo.Domain.Models;

namespace MedGrupo.Service.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();

        }
    }
}
