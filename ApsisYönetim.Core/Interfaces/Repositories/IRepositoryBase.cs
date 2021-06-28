using ApsisYönetim.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity,new()
    {
        Task<int> AddAsync(TEntity item);
        Task<int> Delete(TEntity item);
        Task<int> Update(TEntity item);
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
