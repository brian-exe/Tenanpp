using System.Collections.Generic;
using Tenanpp.Core;
using Tenanpp.Repository.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
 
namespace Tenanpp.Repository
{
    public class BaseRepository<TEntity>: IRepository<TEntity> where TEntity :class
    {
        protected readonly DbContext _context;
 
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
 
        public virtual async Task<TEntity> Get(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
 
        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
 
        // public async Task Update(Inmobiliaria inmobiliaria, Inmobiliaria entity)
        // {
        //     inmobiliaria.Nombre = entity.Nombre;
        //     inmobiliaria.Direccion = entity.Direccion;
        //     inmobiliaria.Localidad = entity.Localidad;
        //     inmobiliaria.Telefono = entity.Telefono;
        //     inmobiliaria.Cuit = entity.Cuit;
        //     inmobiliaria.Url = entity.Url;
        //     await _tenanppContext.SaveChangesAsync();
        // }
 
        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}