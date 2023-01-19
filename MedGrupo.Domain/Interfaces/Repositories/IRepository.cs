using MedGrupo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
