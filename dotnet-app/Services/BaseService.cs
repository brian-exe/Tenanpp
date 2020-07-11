using Tenanpp.Core.Service;
using Tenanpp.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tenanpp.Services{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity :class{

        private protected TenanppContext _context;

        public BaseService(TenanppContext context)
        {
            _context = context;
        }
        public async Task<List<TEntity>> GetAll(){
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetById(long id){
            return await _context.Set<TEntity>().FindAsync(id);
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

         
        // public async Task Add(TEntity entity)
        // {
        //     await _context.Set<TEntity>().AddAsync(entity);
        //     await _context.SaveChangesAsync();
        // }
 
        // public async Task Delete(TEntity entity)
        // {
        //     return _context.Set<TEntity>().Remove(entity);
        //     //await _context.SaveChangesAsync();
        // }
        public void Dispose(){
            _context.Dispose();
        }
    }
}