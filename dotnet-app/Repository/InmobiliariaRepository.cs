using System.Collections.Generic;
using System.Linq;
using Tenanpp.Core;
using Tenanpp.Repository.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
 
namespace Tenanpp.Repository
{
    //public class InmobiliariaRepository : IRepository<Inmobiliaria>
    public class InmobiliariaRepository : BaseRepository<Inmobiliaria>, IInmobiliariaRepository
    {
        public InmobiliariaRepository(TenanppContext context) :base(context)
        {
        }
 
        // public async Task<IEnumerable<Inmobiliaria>> GetAll()
        // {
        //     return await _tenanppContext.Inmobiliarias.ToListAsync();
        // }
 
        public override async Task<Inmobiliaria> Get(long id)
        {
            Thread.Sleep(3000);
            return await TenanppContext.Inmobiliarias.FirstOrDefaultAsync(i => i.InmobiliariaId == id);
        }
 
        // public async Task Add(Inmobiliaria entity)
        // {
        //     await _tenanppContext.Inmobiliarias.AddAsync(entity);
        //     await _tenanppContext.SaveChangesAsync();
        //}
 
        public async Task Update(Inmobiliaria inmobiliaria, Inmobiliaria entity)
        {
            inmobiliaria.Nombre = entity.Nombre;
            inmobiliaria.Direccion = entity.Direccion;
            inmobiliaria.Localidad = entity.Localidad;
            inmobiliaria.Telefono = entity.Telefono;
            inmobiliaria.Cuit = entity.Cuit;
            inmobiliaria.Url = entity.Url;
            await TenanppContext.SaveChangesAsync();
        }
 
        // public async Task Delete(Inmobiliaria inmobiliaria)
        // {
        //     _tenanppContext.Inmobiliarias.Remove(inmobiliaria);
        //     await _tenanppContext.SaveChangesAsync();
        // }
        public TenanppContext TenanppContext
        {
            get { return _context as TenanppContext; }
        }
    }
}