using AutoMapper;
using MedGrupo.CrossCutting.Helper;
using MedGrupo.Domain.Dtos;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Interfaces.Repositories;
using MedGrupo.Domain.Interfaces.Services.User;
using MedGrupo.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Service.Service
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IRepository<UserEntity> repository, IMapper mapper, IConfiguration configuration)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._configuration = configuration;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDto user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.senha = Crypt.Encrypt(model.senha, _configuration["KEY_CRYPT"]);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDto user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.senha = Crypt.Encrypt(model.senha, _configuration["KEY_CRYPT"]);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
