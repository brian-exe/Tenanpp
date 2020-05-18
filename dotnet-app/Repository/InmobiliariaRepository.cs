using System.Collections.Generic;
using System.Linq;
using Tenanpp.Core;
using Tenanpp.Repository.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
 
namespace Tenanpp.Repository
{
    public class InmobiliariaRepository : BaseRepository<Inmobiliaria>, IInmobiliariaRepository
    {
        public InmobiliariaRepository(TenanppContext context) :base(context)
        {
        }
        
        public override async Task<Inmobiliaria> Get(long id)
        {
            return await TenanppContext.Inmobiliarias.FirstOrDefaultAsync(i => i.Id == id);
        }
 
        private TenanppContext TenanppContext
        {
            get { return _context as TenanppContext; }
        }
    }
}