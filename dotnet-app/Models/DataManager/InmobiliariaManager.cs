using System.Collections.Generic;
using System.Linq;
using Tenanpp.Models.Repository;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
 
namespace Tenanpp.Models.DataManager
{
    public class InmobiliariaManager : IDataRepository<Inmobiliaria>
    {
        readonly TenanppContext _tenanppContext;
 
        public InmobiliariaManager(TenanppContext context)
        {
            _tenanppContext = context;
        }
 
        public async Task<IEnumerable<Inmobiliaria>> GetAll()
        {
            return await _tenanppContext.Inmobiliarias.ToListAsync();
        }
 
        public async Task<Inmobiliaria> Get(long id)
        {

            Thread.Sleep(3000);
            return await _tenanppContext.Inmobiliarias.FirstOrDefaultAsync(i => i.InmobiliariaId == id);
        }
 
        public async Task Add(Inmobiliaria entity)
        {
            await _tenanppContext.Inmobiliarias.AddAsync(entity);
            await _tenanppContext.SaveChangesAsync();
        }
 
        public async Task Update(Inmobiliaria inmobiliaria, Inmobiliaria entity)
        {
            inmobiliaria.Nombre = entity.Nombre;
            inmobiliaria.Direccion = entity.Direccion;
            inmobiliaria.Localidad = entity.Localidad;
            inmobiliaria.Telefono = entity.Telefono;
            inmobiliaria.Cuit = entity.Cuit;
            inmobiliaria.Url = entity.Url;
            await _tenanppContext.SaveChangesAsync();
        }
 
        public async Task Delete(Inmobiliaria inmobiliaria)
        {
            _tenanppContext.Inmobiliarias.Remove(inmobiliaria);
            await _tenanppContext.SaveChangesAsync();
        }
    }
}