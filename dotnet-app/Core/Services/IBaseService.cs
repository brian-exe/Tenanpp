using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Tenanpp.Core.Service {
    public interface IBaseService<TEntity>: IDisposable 
            where TEntity : class  {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        // Task Add(TEntity entity);
        // Task Delete(TEntity entity);
        // Task<int> Update(TEntity dbEntity, TEntity entityForUpdate);
    }

}