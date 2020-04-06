using Tenanpp.Core.Service;
using Tenanpp.Core;
using Tenanpp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tenanpp.Services{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity :class{

        private protected UnitOfWork _unitOfWork;

        public BaseService(TenanppContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        public virtual Task<IEnumerable<TEntity>> GetAll(){
            throw new System.NotImplementedException();
        }
        public virtual Task<TEntity> Get(long id){
            throw new System.NotImplementedException();
        }
        // public virtual Task<int> Add(TEntity entity){
        //     throw new System.NotImplementedException();
        // }
        // public virtual Task<int> Delete(TEntity entity){
        //     throw new System.NotImplementedException();
        // }
        // public virtual Task<int> Update(TEntity dbEntity, TEntity entityForUpdate){
        //     throw new System.NotImplementedException();
        //}

        public void Dispose(){
            _unitOfWork.Dispose();
        }
    }
}