using ApsisYönetim.Core.Interfaces.Entity;
using ApsisYönetim.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,IEntity,new() 
    {
        protected readonly ApsisDBContext _context = null;
        private readonly DbSet<TEntity> _entities = null;
        public RepositoryBase(ApsisDBContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<int> AddAsync(TEntity item)
        {
             await _entities.AddAsync(item);
             return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity item)
        {
            _entities.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if(expression == null)
            {
                return await _entities.ToListAsync();
            }

            return await _entities.Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.FirstOrDefaultAsync(expression);
        }


        public async Task<int> Update(TEntity item)
        {
            _entities.Update(item);
            return await _context.SaveChangesAsync();
        }
    }
}
