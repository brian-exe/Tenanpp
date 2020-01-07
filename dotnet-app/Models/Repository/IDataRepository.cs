using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tenanpp.Models.Repository{
        public interface IDataRepository<TEntity>
        {
            Task<IEnumerable<TEntity>> GetAll();
            Task<TEntity> Get(long id);
            Task Add(TEntity entity);
            Task Update(TEntity dbEntity, TEntity entity);
            Task Delete(TEntity entity);
        }
}
