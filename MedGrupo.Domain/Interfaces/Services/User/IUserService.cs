using MedGrupo.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDto aluno);
        Task<UserDtoUpdateResult> Put(UserDto aluno);
        Task<bool> Delete(Guid id);
    }
}
