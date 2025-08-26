using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Services
{

    public class GenericService<T> : IGeneric<T> where T : class
    {
        private readonly HuellasAutomarkDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericService(HuellasAutomarkDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            entity.GetType().GetProperty("IsActive")?.SetValue(entity, false);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public IQueryable<T> Query() => _context.Set<T>().AsQueryable();

        public async Task<IEnumerable<T>> GetAllActiveEntitiesAsync<T>(IQueryable<T> queryable) 
        {
            var parameter = Expression.Parameter(typeof(T), "e");

            // Buscar la propiedad "IsActive"
            var property = Expression.Property(parameter, "IsActive");

            // Expresión e => e.IsActive
            var lambda = Expression.Lambda<Func<T, bool>>(property, parameter);

            return await queryable.Where(lambda).ToListAsync();
        }

    }
}
