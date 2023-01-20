using AutoMapper;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedGrupo.Service.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
