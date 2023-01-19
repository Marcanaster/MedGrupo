using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MedGrupo.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string login, string password);
    }
}
