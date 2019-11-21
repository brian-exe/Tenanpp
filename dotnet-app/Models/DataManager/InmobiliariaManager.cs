using System.Collections.Generic;
using System.Linq;
using Tenanpp.Models.Repository;
 
namespace Tenanpp.Models.DataManager
{
    public class InmobiliariaManager : IDataRepository<Inmobiliaria>
    {
        readonly TenanppContext _tenanppContext;
 
        public InmobiliariaManager(TenanppContext context)
        {
            _tenanppContext = context;
        }
 
        public IEnumerable<Inmobiliaria> GetAll()
        {
            return _tenanppContext.Inmobiliarias.ToList();
        }
 
        public Inmobiliaria Get(long id)
        {
            return _tenanppContext.Inmobiliarias
                  .FirstOrDefault(i => i.InmobiliariaId == id);
        }
 
        public void Add(Inmobiliaria entity)
        {
            _tenanppContext.Inmobiliarias.Add(entity);
            _tenanppContext.SaveChanges();
        }
 
        public void Update(Inmobiliaria inmobiliaria, Inmobiliaria entity)
        {
            inmobiliaria.Nombre = entity.Nombre;
            inmobiliaria.Direccion = entity.Direccion;
            inmobiliaria.Localidad = entity.Localidad;
            inmobiliaria.Telefono = entity.Telefono;
            inmobiliaria.Cuit = entity.Cuit;
            inmobiliaria.Url = entity.Url;
            _tenanppContext.SaveChanges();
        }
 
        public void Delete(Inmobiliaria inmobiliaria)
        {
            _tenanppContext.Inmobiliarias.Remove(inmobiliaria);
            _tenanppContext.SaveChanges();
        }
    }
}