using MedGrupo.Data.Context;
using MedGrupo.Domain.Entities.Base;
using MedGrupo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Data.Repository
{
    public  class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MedGrupoContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MedGrupoContext context)
        {
            this._context = context;
            this._dataSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
                if (result == null) return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty) entity.Create(Guid.NewGuid());

                entity.CreatAt = DateTime.UtcNow;
                _dataSet.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == entity.Id);
                if (result == null) return null;

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreatAt = result.CreatAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }
    }
}
