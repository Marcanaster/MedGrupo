using MedGrupo.Data.Context;
using MedGrupo.Data.Repository;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedGrupo.Data.Implementation
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataSet;
        public UserImplementation(MedGrupoContext context) : base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string login, string password)
        {
            return await _dataSet.FirstOrDefaultAsync(u => u.Login.Equals(login) && u.Senha.Equals(password));
        }
    }
}
