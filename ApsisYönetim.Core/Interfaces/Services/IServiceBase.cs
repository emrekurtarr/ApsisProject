using ApsisYönetim.Core.Interfaces.Entity;
using ApsisYönetim.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class,IEntity,new()
    {
        Task<IResult> AddAsync(TEntity item);
        Task<IResult> Delete(TEntity item);
        Task<IResult> Update(TEntity item);
        Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
